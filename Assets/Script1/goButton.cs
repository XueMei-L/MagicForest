using UnityEngine;

public class GoButton : MonoBehaviour
{
    public GameObject image;
    public GameObject button;

    public void OnClickStart()
    {
        Debug.Log("Button Clicked!");

        if (image != null) image.SetActive(false);
        if (button != null) button.SetActive(false);

        if (GameTimer.Instance != null)
            GameTimer.Instance.StartTimer();
        else
            Debug.LogWarning("GameTimer is NULL");

        if (GameManagerSceneReward.Instance != null)
            GameManagerSceneReward.Instance.StartGame();
        else
            Debug.LogWarning("GameManagerSceneReward is NULL");
    }
}