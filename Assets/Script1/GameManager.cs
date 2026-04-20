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
        StartCoroutine(EnterGameScene());
        Screen.SetResolution(1920, 1080, false);
    }

    private IEnumerator EnterGameScene()
    {
        // Disable camera follow at start
        cameraFollow.isFollowing = false;

        // Disable parallax at start
        parallaxController.isActive = false;

        // Play walking animation
        playerAnimator.SetBool("isWalking", true);

        // Move player into scene
        while (player.position.x < playerStopPoint.position.x - 0.05f)
        {
            player.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap player exactly to stop point
        player.position = new Vector3(
            playerStopPoint.position.x,
            player.position.y,
            player.position.z
        );

        // Stop animation
        playerAnimator.SetBool("isWalking", false);

        yield return new WaitForSeconds(0.1f); // small delay (optional but smoother)

        // Initialize camera correctly (THIS FIXES YOUR PROBLEM)
        // cameraFollow.InitializeFollow(0f); // 0 in the middle of camera
        cameraFollow.InitializeFollow(10f);
        

        // Activate parallax AFTER camera is stable
        parallaxController.ActivateParallax();

        // Enable player control (optional)
        // player.GetComponent<PlayerController>().enabled = true;
    }
}