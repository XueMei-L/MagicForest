using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int currentExp = 0;
    public int maxExp = 100;
    public int level = 1;

    public Image expBarFill; // Drag your Fill Image here in Inspector

    void Start()
    {
        UpdateExpBar();
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

        // Handle level up
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

        Debug.Log("Level Up! Current Level: " + level);
    }

    void UpdateExpBar()
    {
        expBarFill.fillAmount = (float)currentExp / maxExp;
    }
}