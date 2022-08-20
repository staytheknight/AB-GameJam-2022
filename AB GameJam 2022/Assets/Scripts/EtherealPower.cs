using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EtherealPower : MonoBehaviour
{

    bool etherealOn = false;
    [SerializeField] Tilemap gTilemap;
    [SerializeField] Collider2D gCollider;
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
        if (Input.GetButton("EtherealPower"))
        {
            //When button pressed and held, colliders disabled.
            iCollider.enabled = false;
            dCollider.enabled = false;
            gCollider.enabled = false;

            if (Input.GetButtonDown("EtherealPower"))
            {
                //When button initially pressed, set colour transparancy to 0.5 less than current transparency
                gTilemap.color = (Vector4)gTilemap.color - new Vector4(0f, 0f, 0f, gTilemap.color.a - 0.5f);
                iTilemap.color = (Vector4)iTilemap.color - new Vector4(0f, 0f, 0f, iTilemap.color.a - 0.5f);
                dTilemap.color = (Vector4)dTilemap.color - new Vector4(0f, 0f, 0f, dTilemap.color.a - 0.5f);

            }

                } 

        else 
        {
            if (Input.GetButtonUp("EtherealPower"))
            {
                //When button released, set colour transparency to 0.5 more than current transparency
                gTilemap.color = (Vector4)gTilemap.color + new Vector4(0f, 0f, 0f, gTilemap.color.a + 0.5f);
                iTilemap.color = (Vector4)iTilemap.color + new Vector4(0f, 0f, 0f, iTilemap.color.a + 0.5f);
                dTilemap.color = (Vector4)dTilemap.color + new Vector4(0f, 0f, 0f, dTilemap.color.a + 0.5f);
            }

            //When button released, colliders re-enabled.
            iCollider.enabled = true;
            dCollider.enabled = true;
            gCollider.enabled = true;

        }
    }
}
