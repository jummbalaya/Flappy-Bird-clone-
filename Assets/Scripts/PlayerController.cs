using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float pushForce = 5f; // Adjust this to control the jump height
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Add vertical force to the player's Rigidbody
        rb.velocity = new Vector2(rb.velocity.x, pushForce);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            Debug.Log("Game Over");
        }
    }
}
