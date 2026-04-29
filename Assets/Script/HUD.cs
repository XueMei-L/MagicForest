using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Text timerText;

    [Header("Key UI")]
    public GameObject keyUI;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
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