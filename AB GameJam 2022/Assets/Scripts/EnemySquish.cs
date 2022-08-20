using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquish : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float jumpForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collision is detected between player and enemy, kill enemy
        if (collision.collider.tag == "Player")
        {           

            rb2d.AddForce(new Vector2(0f, jumpForce));

            Destroy(transform.parent.gameObject);
        }
    }
}
