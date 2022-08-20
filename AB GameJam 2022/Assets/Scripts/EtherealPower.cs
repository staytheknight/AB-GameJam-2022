using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EtherealPower : MonoBehaviour
{

    bool etherealOn = false;
    [SerializeField] Tilemap iTilemap;
    [SerializeField] Collider2D iCollider;
    [SerializeField] Tilemap dTilemap;
    [SerializeField] Collider2D dCollider;


    private void Start()
    {
        // TODO : Dynamically assigns iTilemap, iCollider, dTilemap & dCollider variables
        // This is because the scene will change and new object references will be needed

        // Can possibly do it with FindObjectsWithTags or something like that
        // Maybe FindObjectsOfType, but there are other objects with the same type as Tilemap_Dangers & Tilemap_Interactables
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EtherealPower"))
        {
            // TODO : Reduce Tilemap opacity (maybe to 50%) (probably using the setColor parameter ?
            // https://docs.unity3d.com/ScriptReference/Tilemaps.Tilemap.html
            iCollider.enabled = false;
            dCollider.enabled = false;
        } 

        else if (Input.GetButtonUp("EtherealPower"))
        {   
            
            // TODO : Revert tilemap opacity changes
            iCollider.enabled = true;
            dCollider.enabled = true;
        }
    }
}
