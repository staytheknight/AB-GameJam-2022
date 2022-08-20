using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquish : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collision is detected between player and enemy, kill enemy
        if (collision.collider.tag == "Player")
        {
            //Vector2 force = new Vector2(xForce, yForce);

            // Wait one second before triggering the impulse
           // yield return new WaitForSeconds(1f);
            // The player controllers need to be turned off in order for proper physics to work
            // TODO : probably put the toggle in a grounded check
            //GetComponent<CharacterController2D>().enabled = false;
            //GetComponent<PlayerMovement>().enabled = false;

            rb2d.AddForce(new Vector2(0f, jumpForce));

            Destroy(transform.parent.gameObject);

            //m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

            //GetComponent<CharacterController2D>().enabled = true;
            //GetComponent<PlayerMovement>().enabled = true;
            //Destroy(gameObject);
        }
    }
}
