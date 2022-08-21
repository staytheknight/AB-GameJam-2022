using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool switchKill = false;
    public bool levelOne = false;                   // Bandaid patch to toggle if the manager is on the first level or not

    public float restartDelay = 0.1f;

    public GameObject completeLevelUI;              // reference to the complete game object UI
    public GameObject failedLevelUI;

    private PowerUps powerUps;

    [SerializeField] GameObject switchKillOnIcon;
    [SerializeField] GameObject switchKillOffIcon;

    void Start()
    {
        powerUps = FindObjectOfType<PowerUps>();
    }

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
        if (!levelOne) { // If it's not level 1 use this 
            if (Input.GetButton("InvertKill") && powerUps.hasInvertKillPower)
            {
                switchKillOnIcon.SetActive(true);
                switchKillOffIcon.SetActive(false);

            }
            else if (powerUps.hasInvertKillPower)
            {
                switchKillOnIcon.SetActive(false);
                switchKillOffIcon.SetActive(true);
            }
            else
            {
                switchKillOnIcon.SetActive(false);
                switchKillOffIcon.SetActive(false);
            }
        }
        
    }
}
