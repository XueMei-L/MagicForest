using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 1.5f;
    public int damage = 10;

    private int direction = 1;

    public void Init(int dir)
    {
        direction = dir;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}