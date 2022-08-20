using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public float nextLevelDelay = 1.3f;



    // When the object is triggered (through collision) 
    void OnTriggerEnter2D()
    {

        gameManager.CompleteLevel();            //Call the complete level function of the game manager

        Invoke("LoadNextLevel", nextLevelDelay);  //Calls the load the next scene method after a delay

    }

    // Loads the next scene 
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // The +1 is to increase the index (ie the next scene)
    }

}
