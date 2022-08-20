using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 0.1f;

    public GameObject completeLevelUI;              // reference to the complete game object UI
    public GameObject failedLevelUI;

    // Used to move the player upon fail
    public CharacterController2D controller;
    public PlayerMovement playerMovement;
    public Rigidbody2D player;
    public float thrust = 20f;
    public float rangeMin = -50f;
    public float rangeMax = 50f;

    // Method for when current level is failed
    public void EndGame()
    {
        if(gameHasEnded == false)                   // If game has not ended, end it
        {
            // Turns on failed level UI
            gameHasEnded = true;
            failedLevelUI.SetActive(true);

            // Launches player
            controller.enabled = false;
            playerMovement.enabled = false;
            transform.position = new Vector2(Random.Range(rangeMin, rangeMax), Random.Range(10, rangeMax));
            player.AddForce(transform.position * thrust);

            Invoke("Restart", restartDelay);       // Invokes Restart method
        }
    }

    // Restarts current scene
    void Restart()                                 
    {   
        // Reloads the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Method for what happens when the level is complete
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);            // Turns on the level complete UI
    }
}
