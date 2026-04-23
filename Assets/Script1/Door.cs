using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door : MonoBehaviour
{
    public string nextSceneName;

    private bool isTransitioning = false;

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
        // Prevent multiple triggers during transition
        if (isTransitioning) return;

        // Only react to player
        if (!collision.CompareTag("Player")) return;

        PlayerController player = collision.GetComponent<PlayerController>();
        if (player == null) return;

        // Optional: require key to enter
        if (!player.hasKey) return;

        // ⭐ Save player's current position before leaving the scene
        PlayerData.Instance.returnPosition = player.transform.position;
        PlayerData.Instance.hasReturnPosition = true;

        // ⭐ Mark this door as used
        PlayerData.Instance.doorUsed = true;

        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        isTransitioning = true;

        // Fade out before changing scene
        if (FadeController.Instance != null)
        {
            yield return FadeController.Instance.FadeOut();
        }

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);

        // Wait one frame to ensure scene is loaded
        yield return null;

        // Fade in after scene loads
        if (FadeController.Instance != null)
        {
            yield return FadeController.Instance.FadeIn();
        }

        isTransitioning = false;
    }
}