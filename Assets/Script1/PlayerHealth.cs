using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBarFill;

    void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        UpdateHealthBar();
    }

    void Update()
    {
        // TEST
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void TakeDamage(int amount)
    {
        PlayerData.Instance.currentHP -= amount;
        PlayerData.Instance.currentHP = Mathf.Max(PlayerData.Instance.currentHP, 0);

        UpdateHealthBar();

        if (PlayerData.Instance.currentHP <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        PlayerData.Instance.currentHP += amount;
        PlayerData.Instance.currentHP = Mathf.Min(
            PlayerData.Instance.currentHP,
            PlayerData.Instance.maxHP
        );

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBarFill.fillAmount =
            (float)PlayerData.Instance.currentHP / PlayerData.Instance.maxHP;
    }
    

    void Die()
    {
        Debug.Log("Player Died");
    }
}