using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : MonoBehaviour
{

    [SerializeField] GameObject rightMusic;
    [SerializeField] GameObject leftMusic;
    [SerializeField] GameObject topMusic;

    // Update is called once per frame
    void Update()
    {   
        // If invert kill toggle is triggered 
        if (Input.GetButton("InvertKill"))
        {
            // Turn on top music sprite, turn off left and right sprite
            topMusic.SetActive(true);
            rightMusic.SetActive(false);
            leftMusic.SetActive(false);

        }
        else
        {   
            // if the button is not pressed, turn off top music, and on left and right
            topMusic.SetActive(false);
            rightMusic.SetActive(true);
            leftMusic.SetActive(true);
        }
    }
}
