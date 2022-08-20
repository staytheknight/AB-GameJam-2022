using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EtherealPower : MonoBehaviour
{

    bool etherealOn = false;
    GameObject interactables;
    GameObject dangers;
    Tilemap iTilemap;

    // Start is called before the first frame update
    void Start()
    {   
        // Grabs and assigns the objects of the tag types
        interactables = GameObject.FindWithTag("Interactables");
        dangers = GameObject.FindWithTag("Dangers");

        //iTilemap = interactables.GetComponents<Tilemap>;
        //iTilemap.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EtherealPower"))
        {
            etherealOn = true;
            
        
        } 

        else if (Input.GetButtonUp("EtherealPower"))
        {
            etherealOn = false;
        }
    }
}
