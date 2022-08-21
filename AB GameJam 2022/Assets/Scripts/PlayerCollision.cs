using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public MusicToggle musicToggle;                    // Scripting object that controls music note visuals

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

        // If collision is detected with boundaries and Wraparound is disabled, end game.
        if (collision.collider.tag == "Boundaries" && !Input.GetButton("Wraparound"))
        {
            Destroy(bottomBoundary);
            Destroy(topBoundary);
            FindObjectOfType<GameManager>().EndGame();
        }

        //If collision is detected with boundaries and Wraparound is enabled, wrap to other side.
        if (collision.collider.tag == "Boundaries" && Input.GetButton("Wraparound"))
        {
            //Wrap to bottom if gravity inverted
            if (playerMovement.isGravityInverted)
                player.transform.position = new Vector3(player.transform.position.x, bottomBoundary.transform.position.y, player.transform.position.z);
            //Wrap to top if gravity normal.
            else
                player.transform.position = new Vector3(player.transform.position.x, topBoundary.transform.position.y, player.transform.position.z);
        }

  

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
        Vector2 launchVector = new Vector2(Random.Range(rangeMin, rangeMax), Random.Range(0, rangeMax));  
        player.AddForce(launchVector);        
    }
}
