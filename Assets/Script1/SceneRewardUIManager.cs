using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardExpUIManager : MonoBehaviour
{
    public Image expBarFill;
    public TextMeshProUGUI levelText;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // ⭐实时刷新UI（简单版）
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (PlayerData.Instance == null) return;

        if (expBarFill != null)
        {
            expBarFill.fillAmount =
                (float)PlayerData.Instance.currentExp / PlayerData.Instance.maxExp;
        }

        if (levelText != null)
        {
            levelText.text =
                "Level: " + PlayerData.Instance.level;
        }
    }
}