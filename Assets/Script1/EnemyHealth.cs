using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 50;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        Debug.Log("Enemy HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        // ⭐ Give EXP
        if (PlayerExperience.Instance != null)
        {
            PlayerExperience.Instance.AddExp(50);
        }

        Destroy(gameObject);
    }
}