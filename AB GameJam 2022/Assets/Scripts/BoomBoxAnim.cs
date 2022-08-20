using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoxAnim : MonoBehaviour
{   

    Vector3 startRotation;

    [SerializeField] float switchTime = 0f;
    public float zSpeen = 0.3f;
    float elapsedTime = 0f;

    // Instantiates a Vector3 for rotation
    private void Start()
    {
        transform.eulerAngles = startRotation;
    }

    // Calls rotation, and after a certain amount of time has elapsed calls the reverse rotation function
    void Update()
    {
        Rotate();

        if (elapsedTime >= switchTime)
        {
            InvertRotation();
            elapsedTime = 0f;
        }

        elapsedTime += 0.3f;
    }

    void Rotate()
    {
        transform.Rotate(0,0, zSpeen);
    }

    // Reverses the rotation 
    void InvertRotation()
    {
        zSpeen = -zSpeen;
    }
}
