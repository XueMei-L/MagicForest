using UnityEngine;
using System.Collections;

public class FireEffect : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 direction = Vector3.left;
    public float lifeTime = 3f;

    public int damage = 10;

    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}