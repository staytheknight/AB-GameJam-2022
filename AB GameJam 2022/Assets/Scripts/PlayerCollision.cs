using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    // Used to move the player upon fail
    public CharacterController2D controller;
    public PlayerMovement playerMovement;
    public Rigidbody2D player;
    public float thrust = 20f;
    public float rangeMin = -50f;
    public float rangeMax = 50f;

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        // If collision is detected between player dangers or boundaries end the game
        if(collision.collider.tag == "Dangers")
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collision.collider.tag == "Boundaries")
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collision.collider.tag == "Enemy")
        {
            // Launches player
            controller.enabled = false;
            playerMovement.enabled = false;
            transform.position = new Vector2(Random.Range(rangeMin, rangeMax), Random.Range(0, rangeMax));
            player.AddForce(transform.position * thrust);

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
