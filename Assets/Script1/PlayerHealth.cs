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
        if (PlayerData.Instance == null) return;

        PlayerData.Instance.currentHP -= amount;
        PlayerData.Instance.currentHP = Mathf.Max(PlayerData.Instance.currentHP, 0);

        UpdateHealthBar();

        Debug.Log("Player HP: " + PlayerData.Instance.currentHP);

        if (PlayerData.Instance.currentHP <= 0)
        {
            PlayerController controller = GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.Die();
            }
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
    
}