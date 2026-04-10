// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public float speed = 10f;

//     void Update()
//     {
//         // get horizontal input
//         float horizontalInput  = Input.GetAxisRaw("Horizontal");

//         // Create a movement vector
//         Vector2 movement = new Vector2(horizontalInput, 0f);

//         // Move the object frame rate independently
//         transform.Translate(movement * speed * Time.deltaTime);
//     }
// }
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    // Movement settings
    public float speed = 5f;
    public float jumpForce = 7f;

    // State control
    private bool isGrounded = true;
    private bool isDead = false;

    void Start()
    {
        // Get required components
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Stop all input if the player is dead
        if (isDead) return;

        // Get horizontal input (-1, 0, 1)
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        // -------- Movement --------
        // Apply horizontal velocity while keeping vertical velocity
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);

        // -------- Flip character --------
        // Flip sprite based on movement direction
        if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }
        else if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = false; // Facing right
        }

        // -------- Idle / Run animation --------
        // Set running animation based on movement
        animator.SetBool("isWalking", moveHorizontal != 0);

        // -------- Jump --------
        // Allow jump only when grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("jump");
            isGrounded = false;
        }

        // -------- Attack --------
        // Trigger attack animation
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("attack");
        }

        // -------- Death --------
        // Trigger death animation manually (for testing)
        if (Input.GetKeyDown(KeyCode.M))
        {
            Die();
        }
    }

    void Die()
    {
        // Set player as dead
        isDead = true;

        // Stop movement
        rb.linearVelocity = Vector2.zero;

        // Play death animation
        animator.SetTrigger("die");
    }

    // -------- Ground detection --------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player touches ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}