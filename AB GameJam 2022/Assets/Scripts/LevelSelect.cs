using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_tmp;
    private string[] levelText = new string[4] { "Level 1", "Level 2", "Level 3", "Level 4" }; //Array of levels. Needs to be updated when new levels added.
    private int levelNumber = 0; //Start at level index 0.
    private bool m_isAxisInUse = false; //Used to prevent key repeat on horizontal axis.
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0) //If moving left
        {
            if (m_isAxisInUse == false) //And axis not currently in use.
            {
                m_isAxisInUse = true; //Set axis in use to true

                if (levelNumber > 0) //decrease level number
                    levelNumber--;
                else //wrap to max if hit level 1.
                    levelNumber = levelText.Length - 1;
                m_tmp.text = levelText[levelNumber]; //Show level name
            }
        }
        if (Input.GetAxisRaw("Horizontal") > 0) //If moving right
        {
            if (m_isAxisInUse == false) //And axis not currently in use.
            {
                m_isAxisInUse = true; //Set axis in use to tru

                if (levelNumber < levelText.Length - 1) //increase level number
                    levelNumber++;
                else //wrap to min if hit max level.
                    levelNumber = 0;
                m_tmp.text = levelText[levelNumber]; //Show level name
            }
        }

        if (Input.GetAxisRaw("Horizontal") == 0) //Reset to axis not in use once keys released.
        {
            m_isAxisInUse = false;
        }

            if (Input.GetButtonDown("Jump")) //use jump button to select level.
        {
            SceneManager.LoadScene(levelNumber);
        }
    }
}
