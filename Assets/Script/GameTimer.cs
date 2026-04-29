using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    // public float levelTime = 20f;
    public float levelTime = 10f;
    private float currentTime;
    private bool isRunning = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentTime = levelTime;

        if (HUD.Instance != null)
        {
            HUD.Instance.UpdateTimer(currentTime);
        }
    }

    public void StartTimer()
    {
        currentTime = levelTime;
        isRunning = true;
    }

    private void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (HUD.Instance != null)
        {
            HUD.Instance.UpdateTimer(currentTime);
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            isRunning = false;

            OnTimeUp();
        }
    }

    private void OnTimeUp()
    {
        Debug.Log("Time is up!");

        GameManagerSceneReward.Instance?.TriggerGameOver();
    }
}