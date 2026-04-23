using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    public float levelTime = 20f;
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
        // ⭐ TEST ONLY: press Y to force time = 0
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ForceTimeUp();
        }

        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        HUD.Instance.UpdateTimer(currentTime);

        if (currentTime <= 0)
        {
            currentTime = 0;
            isRunning = false;

            OnTimeUp();
        }
    }

    // ⭐ NEW TEST FUNCTION (safe addition)
    private void ForceTimeUp()
    {
        currentTime = 0;
        isRunning = false;
        OnTimeUp();
    }

    private void OnTimeUp()
    {
        Debug.Log("Time is up!");
    }
}