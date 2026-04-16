using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door : MonoBehaviour
{
    public string nextSceneName;

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTransitioning) return;

        if (!collision.CompareTag("Player")) return;

        PlayerController player = collision.GetComponent<PlayerController>();
        if (player == null) return;

        // Optional condition (you can remove if not needed)
        if (!player.hasKey) return;

        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        isTransitioning = true;

        // 1. Fade out
        if (FadeController.Instance != null)
        {
            yield return FadeController.Instance.FadeOut();
        }

        // 2. Load next scene
        SceneManager.LoadScene(nextSceneName);

        // 3. Wait one frame so scene is fully initialized
        yield return null;

        // 4. Fade in
        if (FadeController.Instance != null)
        {
            yield return FadeController.Instance.FadeIn();
        }

        isTransitioning = false;
    }
}