using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquish : MonoBehaviour
{

    public MusicToggle musicToggle;

    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float jumpForce = 300f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Old code for button press - KEPT JUST IN CASE
        // If collision is detected between player and enemy, kill enemy if Invert Kill not activated.
        if (collision.collider.tag == "Player" && !Input.GetButton("InvertKill")
        {           

            rb2d.AddForce(new Vector2(0f, jumpForce));

            Destroy(transform.parent.gameObject);
        }
        //If collision is detected between player and enemy and Invert Kill activated, kill player.
        else if (collision.collider.tag == "Player" && Input.GetButton("InvertKill"))
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            FindObjectOfType<GameManager>().EndGame();
        }*/

        // Checks collision with player and if the music graphic inverted enemy toggle is set
        if (collision.collider.tag == "Player" && !musicToggle.invertedEnemy)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            Destroy(transform.parent.gameObject);
        }
        else if (collision.collider.tag == "Player" && musicToggle.invertedEnemy)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            FindObjectOfType<GameManager>().EndGame();
            FindObjectOfType<PlayerCollision>().PlayerLaunch();
        }
    }

}
