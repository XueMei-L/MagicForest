using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Image healthBarFill; // Drag HP Fill Image

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // TEST: Press J to take damage
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(20);
        }

        // TEST: Press H to heal
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBarFill.fillAmount = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        Debug.Log("Player Died");
    }
}