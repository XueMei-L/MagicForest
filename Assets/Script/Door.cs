using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door : MonoBehaviour
{
    public string nextSceneName;

    private bool isTransitioning = false;

    public GameObject keyUI;
    
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

        // check user has key?
        if (!PlayerData.Instance.hasKey)
        {
            Debug.Log("Need a key!");
            return;
        }

        // set hasKey false
        PlayerData.Instance.hasKey = false;

        // UI disapear
        if (keyUI != null)
            keyUI.SetActive(false);

        // save player position
        PlayerData.Instance.returnPosition = player.transform.position;
        PlayerData.Instance.hasReturnPosition = true;

        // Set dorr true
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