using UnityEngine;

public class GoButton : MonoBehaviour
{
    public GameObject image;
    public GameObject button;

    public void OnClickStart()
    {
        Debug.Log("Button Clicked!");

        image.SetActive(false);
        button.SetActive(false);

        GameTimer.Instance.StartTimer();

        GameManagerSceneReward.Instance.StartGame(); 
    }
}