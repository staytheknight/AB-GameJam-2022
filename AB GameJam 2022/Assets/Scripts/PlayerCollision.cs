using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    // Used to move the player upon fail
    public CharacterController2D controller;
    public PlayerMovement playerMovement;
    public Rigidbody2D player;
    public GameObject boundary;
    public float rangeMin = -400f;
    public float rangeMax = 400f;

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
            Destroy(boundary);
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collision.collider.tag == "Enemy")
        {
            PlayerLaunch();
            FindObjectOfType<GameManager>().EndGame();
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
