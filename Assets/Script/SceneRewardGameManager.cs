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
    }

    // ⭐ called by GameTimer
    public void TriggerGameOver()
    {
        if (gameOver) return;

        gameOver = true;
        gameStarted = false;

        StartCoroutine(GameOverRoutine());
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(0.2f); // small delay for safety

        Time.timeScale = 0f;

        if (timeoutUI != null)
            timeoutUI.SetActive(true);
    }

    public void BackToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene1Spring");
    }
}