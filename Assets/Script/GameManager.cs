using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Animator playerAnimator;
    public CameraFollow cameraFollow;
    public ParallaxController parallaxController;
    public Transform playerStopPoint;

    public float moveSpeed = 2f;

    void Start()
    {
        if (PlayerData.Instance.hasReturnPosition)
        {
            Debug.Log("Back to position: " + PlayerData.Instance.returnPosition);

            // 1. Restore player position
            player.position = PlayerData.Instance.returnPosition;
            PlayerData.Instance.hasReturnPosition = false;

            // 2. reinitialize camera system
            StartCoroutine(ResumeSceneAfterReturn());
        }
        else
        {
            StartCoroutine(EnterGameScene());
        }
    }

    private IEnumerator ResumeSceneAfterReturn()
    {
        yield return null;

        parallaxController.isActive = true;
        parallaxController.ActivateParallax();
    }

    private IEnumerator EnterGameScene()
    {
        cameraFollow.isFollowing = false;
        parallaxController.isActive = false;

        playerAnimator.SetBool("isWalking", true);

        while (player.position.x < playerStopPoint.position.x - 0.05f)
        {
            player.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            yield return null;
        }

        player.position = new Vector3(
            playerStopPoint.position.x,
            player.position.y,
            player.position.z
        );

        playerAnimator.SetBool("isWalking", false);

        yield return new WaitForSeconds(0.1f);

        cameraFollow.InitializeFollow(10f);
        parallaxController.ActivateParallax();
    }
}