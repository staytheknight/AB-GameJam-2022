using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    // When the object is triggered (through collision) 
    private void OnTriggerEnter()
    {
        gameManager.CompleteLevel();            //Call the complete level function of the game manager
        Debug.Log("Level Finished");
    }

}
