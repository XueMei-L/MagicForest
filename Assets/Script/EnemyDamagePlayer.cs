using UnityEngine;

public class EnemyDamagePlayer : MonoBehaviour
{
    public int damage = 10;
    public float damageInterval = 1f;

    private float timer;
    private bool isTouching;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        isTouching = true;
        timer = 0f;

        DealDamage(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (!isTouching) return;

        timer += Time.deltaTime;

        if (timer >= damageInterval)
        {
            DealDamage(collision);
            timer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        isTouching = false;
        timer = 0f;
    }

    void DealDamage(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponentInParent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}