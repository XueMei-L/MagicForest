using UnityEngine;

public class EndLevelDoor : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject exitButton;

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
        endPanel.SetActive(true);
        exitButton.SetActive(true);

        Time.timeScale = 0f;
    }
}