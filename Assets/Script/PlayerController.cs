using UnityEngine;
using UnityEngine.SceneManagement;
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
    public bool hasKey = true;

    // attackeffect
    public GameObject starEffectPrefab;

    void Start()
    {
        // Get required components
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "RewardExp")
        {
            if (GameManagerSceneReward.Instance == null) return;

            if (!GameManagerSceneReward.Instance.gameStarted || 
                GameManagerSceneReward.Instance.gameOver)
                return;
        }

        if (isDead) return;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);

        if (moveHorizontal < 0)
            spriteRenderer.flipX = true;
        else if (moveHorizontal > 0)
            spriteRenderer.flipX = false;

        animator.SetBool("isWalking", moveHorizontal != 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("jump");
            isGrounded = false;
        }

        // for testing
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.M))
            Die();
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        // Stop movement
        rb.linearVelocity = Vector2.zero;

        // Disable input
        this.enabled = false;

        // Play animation
        animator.SetTrigger("die");

        Debug.Log("Player Died");
    }

    // -------- Ground detection --------
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.transform.root.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    void SpawnStarEffect()
    {
        int dir = spriteRenderer.flipX ? -1 : 1;

        Vector3 spawnPos = transform.position + new Vector3(dir * 1f, 0, 0);

        GameObject star = Instantiate(starEffectPrefab, spawnPos, Quaternion.identity);

        PlayerAttackEffect effect = star.GetComponent<PlayerAttackEffect>();
        effect.Init(dir);
    }
}