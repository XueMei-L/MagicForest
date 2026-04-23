using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManagerSceneReward : MonoBehaviour
{
    public static GameManagerSceneReward Instance;

    public bool gameStarted = false;
    public bool gameOver = false;

    [Header("UI")]
    public GameObject timeoutUI; 

    void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        gameStarted = true;
        gameOver = false;

        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(3f);
        // yield return new WaitForSeconds(20f);

        TriggerGameOver();
    }

    void TriggerGameOver()
    {
        gameOver = true;
        gameStarted = false;

        Time.timeScale = 0f; // ⭐冻结所有

        if (timeoutUI != null)
            timeoutUI.SetActive(true);
    }

    public void BackToMain()
    {
        Time.timeScale = 1f; // ⭐恢复时间
        SceneManager.LoadScene("GameScene1Spring");
    }
}