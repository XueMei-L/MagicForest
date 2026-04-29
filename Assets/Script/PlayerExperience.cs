using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperience : MonoBehaviour
{
    public static PlayerExperience Instance;

    public Image expBarFill;
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        RefreshUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddExp(50);
            Debug.Log("Add hp 50");
        }
    }

    public void AddExp(int amount)
    {
        PlayerData.Instance.currentExp += amount;

        while (PlayerData.Instance.currentExp >= PlayerData.Instance.maxExp)
        {
            PlayerData.Instance.currentExp -= PlayerData.Instance.maxExp;
            PlayerData.Instance.level++;
            PlayerData.Instance.maxExp += 50;

            Debug.Log("Level Up! → " + PlayerData.Instance.level);
        }

        RefreshUI();
    }

    void RefreshUI()
    {
        if (PlayerData.Instance == null) return;

        if (expBarFill != null)
        {
            expBarFill.fillAmount =
                (float)PlayerData.Instance.currentExp /
                PlayerData.Instance.maxExp;
        }

        if (levelText != null)
        {
            levelText.text = "Level: " + PlayerData.Instance.level;
        }
    }
}