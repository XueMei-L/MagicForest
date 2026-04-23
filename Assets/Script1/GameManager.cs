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
        Screen.SetResolution(1920, 1080, false);

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

        // 1. Ensure camera is active
        cameraFollow.isFollowing = true;

        // // 2. FORCE camera to snap to player first
        // cameraFollow.transform.position = new Vector3(
        //     player.position.x,
        //     player.position.y +5,
        //     cameraFollow.transform.position.z
        // );

        // 3. Reinitialize follow logic AFTER snapping
        cameraFollow.InitializeFollow(-5f);

        // 4. Reactivate parallax
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