using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        target = pointB;
    }

    void Update()
    {
        Move();
        CheckSwitchPoint();
    }

    void Move()
    {
        float dir = (target.position.x > transform.position.x) ? 1f : -1f;

        rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);

        spriteRenderer.flipX = dir > 0;
    }

    void CheckSwitchPoint()
    {
        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            SwitchTarget();
        }
    }

    void SwitchTarget()
    {
        target = (target == pointA) ? pointB : pointA;
    }
}