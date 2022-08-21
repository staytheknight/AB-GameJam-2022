using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float switchTime;                           // How long it takes for an enemy to turn around
    float elapsedTime = 0f;
    [SerializeField] float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        switchTime = Random.Range(80f, 120f);   // Sets a random time for the dinos to switch
    }

    // Jank movement code, isn't stable / reliable, will need to change
    void Update()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        if (elapsedTime >= switchTime)
        {
            invertMovement();
            elapsedTime = 0f;
        }

        elapsedTime += 0.3f;
    }

    void invertMovement()
    {
        horizontalMove = -horizontalMove;
    }
}
