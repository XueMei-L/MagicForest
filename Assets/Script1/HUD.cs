using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Text timerText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateTimer(float time)
    {
        timerText.text = Mathf.Ceil(time).ToString();
    }
}