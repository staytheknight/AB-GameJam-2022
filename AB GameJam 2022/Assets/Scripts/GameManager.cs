using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool switchKill = false;

    public float restartDelay = 0.1f;

    public GameObject completeLevelUI;              // reference to the complete game object UI
    public GameObject failedLevelUI;

    [SerializeField] GameObject switchKillOnIcon;
    [SerializeField] GameObject switchKillOffIcon;

    // Method for when current level is failed
    public void EndGame()
    {
        if(gameHasEnded == false)                   // If game has not ended, end it
        {
            // Turns on failed level UI
            gameHasEnded = true;
            failedLevelUI.SetActive(true);

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

    public void Update()
    {
        if (Input.GetButton("InvertKill"))
        {
            switchKillOnIcon.SetActive(true);
            switchKillOffIcon.SetActive(false);

        }
        else
        {
            switchKillOnIcon.SetActive(false);
            switchKillOffIcon.SetActive(true);
        }
    }
}
