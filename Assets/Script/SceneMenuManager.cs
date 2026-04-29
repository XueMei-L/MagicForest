using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Transform player;
    public Animator playerAnimator;

    public float moveSpeed = 3f;
    public float exitX = 10f;

    private bool isStarting = false;

    public void StartGame()
    {
        if (isStarting) return;

        isStarting = true;

        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.ResetData();
        }
        
        StartCoroutine(StartGameSequence());
    }

    private IEnumerator StartGameSequence()
    {
        playerAnimator.SetBool("isWalking", true);

        while (player.position.x < exitX)
        {
            player.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            yield return null;
        }

        SceneManager.LoadScene("GameScene1Spring");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}