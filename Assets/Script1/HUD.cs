using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Text timerText;

    [Header("Key UI")]
    public GameObject keyUI; // ⭐ 加这一行

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // ⭐ 初始化钥匙UI状态
        if (PlayerData.Instance != null)
        {
            if (PlayerData.Instance.hasKey)
                keyUI.SetActive(true);
            else
                keyUI.SetActive(false);
        }
    }

    public void UpdateTimer(float time)
    {
        timerText.text = Mathf.Ceil(time).ToString();
    }
}