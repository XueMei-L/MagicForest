using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door : MonoBehaviour
{
    public string nextSceneName;

    private bool isTransitioning = false;

    public GameObject keyUI; // ⭐ UI icon

    void Start()
    {
        // Hide the door if it has already been used
        if (PlayerData.Instance != null && PlayerData.Instance.doorUsed)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Prevent multiple triggers
        if (isTransitioning) return;

        // Only react to player
        if (!collision.CompareTag("Player")) return;

        PlayerController player = collision.GetComponent<PlayerController>();
        if (player == null) return;

        // ⭐ 用 PlayerData 判断（不要用 player.hasKey）
        if (!PlayerData.Instance.hasKey)
        {
            Debug.Log("Need a key!");
            return;
        }

        // ⭐ 消耗钥匙
        PlayerData.Instance.hasKey = false;

        // ⭐ UI消失
        if (keyUI != null)
            keyUI.SetActive(false);

        // ⭐ 保存玩家位置
        PlayerData.Instance.returnPosition = player.transform.position;
        PlayerData.Instance.hasReturnPosition = true;

        // ⭐ 标记门已使用
        PlayerData.Instance.doorUsed = true;

        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        isTransitioning = true;

        // Fade out
        if (FadeController.Instance != null)
        {
            yield return FadeController.Instance.FadeOut();
        }

        // Load next scene
        SceneManager.LoadScene(nextSceneName);

        yield return null;

        // Fade in
        if (FadeController.Instance != null)
        {
            yield return FadeController.Instance.FadeIn();
        }

        isTransitioning = false;
    }
}