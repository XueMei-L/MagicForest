using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperience : MonoBehaviour
{
    public Image expBarFill;
    public TextMeshProUGUI levelText;

    void Start()
    {
        RefreshUI();
    }

    void Update()
    {
        // TEST
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(20);
        }
    }

    public void AddExp(int amount)
    {
        PlayerData.Instance.currentExp += amount;

        // ⭐ Level up check
        if (PlayerData.Instance.currentExp >= PlayerData.Instance.maxExp)
        {
            LevelUp();
        }

        RefreshUI();
    }

    void LevelUp()
    {
        PlayerData.Instance.level++;
        PlayerData.Instance.currentExp -= PlayerData.Instance.maxExp;
        PlayerData.Instance.maxExp += 50;

        Debug.Log("Level Up! → " + PlayerData.Instance.level);

        RefreshUI();
    }

    void RefreshUI()
    {
        if (expBarFill != null)
        {
            expBarFill.fillAmount =
                (float)PlayerData.Instance.currentExp / PlayerData.Instance.maxExp;
        }

        if (levelText != null)
        {
            levelText.text = "Level: " + PlayerData.Instance.level;
        }
    }
}