using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update () {
		
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		//Gets the absolute value of the horizontal movement and updates the speed parameter for the animator to trigger run animation
		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));				

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

        /*if (Input.GetButtonDown("Crouch"))
		{
			    crouch = true;
		} 

	    else if (Input.GetButtonUp("Crouch"))
		{
		    crouch = false;
		}*/

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}