using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 0.1f;

    public void EndGame()
    {
        if(gameHasEnded == false)                   // If game has not ended, end it
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);       // Invokes Restart method
        }
    }

    void Restart()                                 // Restarts current scene
    {   
        // Reloads the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
