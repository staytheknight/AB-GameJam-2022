using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField] float switchTime = 0f;
    float elapsedTime = 0f;
    [SerializeField] float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    

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
