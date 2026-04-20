using UnityEngine;
using UnityEngine.UI;
using TMPro; // ⭐ needed for TextMeshPro

public class PlayerExperience : MonoBehaviour
{
    public int currentExp = 0;
    public int maxExp = 100;
    public int level = 1;

    public Image expBarFill;        // Drag Fill Image here
    public TextMeshProUGUI levelText; // ⭐ Drag Level Text here

    void Start()
    {
        UpdateExpBar();
        UpdateLevelText();
    }

    void Update()
    {
        // TEST: Press K to add experience
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(20);
        }
    }

    public void AddExp(int amount)
    {
        currentExp += amount;

        // Check level up
        if (currentExp >= maxExp)
        {
            LevelUp();
        }

        UpdateExpBar();
    }

    void LevelUp()
    {
        level++;
        currentExp -= maxExp;
        maxExp += 50;

        UpdateLevelText(); // ⭐ update UI

        Debug.Log("Level Up! Current Level: " + level);
    }

    void UpdateExpBar()
    {
        expBarFill.fillAmount = (float)currentExp / maxExp;
    }

    void UpdateLevelText()
    {
        levelText.text = "Level: " + level;
    }
}