using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Animator playerAnimator;
    public CameraFollow cameraFollow;

    public Transform PlayerStopPoint;

    public float moveSpeed = 2f;
    public float targetX = 0f;

    void Start()
    {
        StartCoroutine(EnterGameScene());
    }

    private IEnumerator EnterGameScene()
    {
        cameraFollow.isFollowing = false;

        playerAnimator.SetBool("isWalking", true);

        while (player.position.x < PlayerStopPoint.position.x)
        {
            player.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            yield return null;
        }

        playerAnimator.SetBool("isWalking", false);

        cameraFollow.isFollowing = true;

        // player.GetComponent<PlayerController>().enabled = true;
    }
}