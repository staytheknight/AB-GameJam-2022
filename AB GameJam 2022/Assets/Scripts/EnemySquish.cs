using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquish : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float jumpForce;
    bool switchKill = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collision is detected between player and enemy, kill enemy if Invert Kill not activated.
        if (collision.collider.tag == "Player" && !Input.GetButton("InvertKill"))
        {           

            rb2d.AddForce(new Vector2(0f, jumpForce));

            Destroy(transform.parent.gameObject);
        }
        //If collision is detected between player and enemy and Invert Kill activated, kill player.
        else if (collision.collider.tag == "Player" && Input.GetButton("InvertKill"))
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
