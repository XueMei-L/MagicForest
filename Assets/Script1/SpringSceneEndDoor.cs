using UnityEngine;

public class EndLevelDoor : MonoBehaviour
{
    public GameObject endPanel;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;

        if (!collision.CompareTag("Player")) return;

        triggered = true;

        ShowEndUI();
    }

    void ShowEndUI()
    {
        if (endPanel != null)
            endPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}