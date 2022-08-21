using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	private Rigidbody2D m_Rigidbody2D;
	private CharacterController2D m_CharacterController2D;

	//Sets gravity state, whether gravity has been updated this frame.
	public bool isGravityInverted = false;
	private bool gravityUpdatedThisFrame = false;

	private bool m_FacingUp = true;  // For determining whether player is facing up or down.

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    // Powerups
	private PowerUps powerUps;
    // Icons for Gravity powerup controls
    [SerializeField] GameObject gravityIconOn;
    [SerializeField] GameObject gravityIconOff;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_CharacterController2D = GetComponent<CharacterController2D>();
		powerUps = FindObjectOfType<PowerUps>();
	}

	// Update is called once per frame
	void Update () {
		
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		//Gets the absolute value of the horizontal movement and updates the speed parameter for the animator to trigger run animation
		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));				

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		//If Gravity invert has been toggled, gravity is currently normal, gravity has not yet been updated this frame, and character is on the floor, invert gravity.
		if (Input.GetButtonDown("InvertGravity") && isGravityInverted == false && gravityUpdatedThisFrame == false && m_CharacterController2D.m_Grounded == true && powerUps.hasGravityPower)
        {
			isGravityInverted = true;
			gravityUpdatedThisFrame = true;            
        }

		//If Gravity invert has been toggled, gravity is currently inverted, gravity has not yet been updated this frame, and character is on the ceiling, put gravity back to normal.
		if (Input.GetButtonDown("InvertGravity") && isGravityInverted == true && gravityUpdatedThisFrame == false && m_CharacterController2D.m_Ceilinged == true && powerUps.hasGravityPower)
        {
			isGravityInverted = false;
			gravityUpdatedThisFrame = true;
                        
        }


        // Checks every frame for conditions to display proper controller icon
        if (isGravityInverted && powerUps.hasGravityPower)
        {

            gravityIconOn.SetActive(true);
            gravityIconOff.SetActive(false);

        }
        else if (!isGravityInverted && powerUps.hasGravityPower)
        {

            gravityIconOn.SetActive(false);
            gravityIconOff.SetActive(true);
        }
        else
        {
            gravityIconOn.SetActive(false);
            gravityIconOff.SetActive(false);
        }




        // If Gravity is inverted, flip gravity scale. If not inverted, leave gravity scale to 1.
        if (isGravityInverted)
			m_Rigidbody2D.gravityScale = -1;
		else
			m_Rigidbody2D.gravityScale = 1;

		// If gravity is up and the player is facing up...
		if (isGravityInverted && m_FacingUp)
		{
			// ... Invert the player.
			Invert();
		}
		// Otherwise if gravity is down and the player is facing down...
		else if (!isGravityInverted && !m_FacingUp)
		{
			// ... Invert the player.
			Invert();
		}

		/*if (Input.GetButtonDown("Crouch"))
		{
			    crouch = true;
		} 

	    else if (Input.GetButtonUp("Crouch"))
		{
		    crouch = false;
		}*/

		gravityUpdatedThisFrame = false;
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	private void Invert()
	{
		// Switch the way the player is labelled as facing.
		m_FacingUp = !m_FacingUp;

		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
		sprite.flipY = !sprite.flipY;

	}
}