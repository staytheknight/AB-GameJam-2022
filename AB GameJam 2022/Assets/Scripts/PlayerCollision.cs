using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public MusicToggle musicToggle;

    // Used to move the player upon fail
    public CharacterController2D controller;
    public PlayerMovement playerMovement;
    public Rigidbody2D player;
    public GameObject bottomBoundary;
    public GameObject topBoundary;
    public float rangeMin = -400f;
    public float rangeMax = 400f;

    private void Update()
    {
        if (playerMovement.isGravityInverted)
        {
            topBoundary.SetActive(true);
            bottomBoundary.SetActive(false);
        }
        else
        {
            topBoundary.SetActive(false);
            bottomBoundary.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        // If collision is detected between player dangers or boundaries end the game
        if(collision.collider.tag == "Dangers")
        {
            PlayerLaunch();
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collision.collider.tag == "Boundaries")
        {
            Destroy(bottomBoundary);
            Destroy(topBoundary);
            FindObjectOfType<GameManager>().EndGame();
        }

        /* OLD CODE FOR INVERT KILL -- USES BUTTONS INSTEAD OF TOGGLE -- KEPT JUST IN CASE
        //If enemy collision happens and invert kill deactivated
        if (collision.collider.tag == "Enemy" && !Input.GetButton("InvertKill"))
        {
            PlayerLaunch();
            FindObjectOfType<GameManager>().EndGame();
        }
        //If enemy collision happens and invert kill activated
        else if (collision.collider.tag == "Enemy" && Input.GetButton("InvertKill"))
        {
        //Get collided enemy game object and destroy it.
            GameObject enemy = collision.collider.gameObject;
            Destroy(enemy);
        }*/

        if (collision.collider.tag == "Enemy")
        {   
            // Get the musicToggle script from the object collided with
            musicToggle = collision.gameObject.GetComponent<MusicToggle>();

            // If the script has inverted enemy tag set to false
            if (!musicToggle.invertedEnemy)
            {
                PlayerLaunch();
                FindObjectOfType<GameManager>().EndGame();
            }
            // If the script has inverted enemy tag set to true
            else if (musicToggle.invertedEnemy)
            {
                //Get collided enemy game object and destroy it.
                GameObject enemy = collision.collider.gameObject;
                Destroy(enemy);
            }

        }


        
    }

    void PlayerLaunch()
    {
        // Launches player
        controller.enabled = false;
        playerMovement.enabled = false;
        Vector2 launchVector = new Vector2(Random.Range(rangeMin, rangeMax), Random.Range(0, rangeMax));  // THIS LINE IS CAUSING ISSUES
        player.AddForce(launchVector);        
    }
}
