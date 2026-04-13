// using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     public Transform player; // Assign the player in inspector
//     public float smoothSpeed = 0.1f; // Camera smooth movement
//     private Vector3 offset; // Initial offset between camera and player

//     void Start()
//     {
//         if (player == null)
//         {
//             Debug.LogError("Player not assigned!");
//         }
//         offset = transform.position - player.position;
//     }

//     void LateUpdate()
//     {
//         // Target position with offset
//         Vector3 targetPos = player.position + offset;
//         targetPos.z = -10; // Keep camera at fixed Z

//         // Smoothly move camera
//         transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
//     }
// }

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.1f;

    private Vector3 offset;

    public bool isFollowing = false;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("CameraFollow: Player not assigned!");
            return;
        }

        // Initial offset (will be recalculated later)
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (!isFollowing || player == null)
            return;

        // Target position based on player + offset
        Vector3 targetPos = player.position + offset;
        targetPos.z = -10;

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }

    // ⭐ Force camera to snap instantly to player position
    public void SnapToPlayer()
    {
        if (player == null) return;

        Vector3 targetPos = player.position + offset;
        targetPos.z = -10;

        transform.position = targetPos;
    }

    // ⭐ Recalculate offset (VERY IMPORTANT)
    public void ResetOffset()
    {
        if (player == null) return;

        offset = transform.position - player.position;
    }

    // ⭐ Initialize camera correctly (BEST METHOD)
    public void InitializeFollow(float offsetX = 0f)
    {
        if (player == null) return;

        // Move camera to correct position first
        transform.position = new Vector3(
            player.position.x + offsetX,
            transform.position.y,
            -10
        );

        // Recalculate offset AFTER positioning
        offset = transform.position - player.position;

        // Enable follow
        isFollowing = true;
    }
    // function to calculate the position of player
    // public void InitializeAtPosition(Vector3 targetPosition, float offsetX)
    // {
    //     if (player == null) return;

    //     // Place camera based on stop point + offset
    //     transform.position = new Vector3(
    //         targetPosition.x + offsetX,
    //         transform.position.y,
    //         -10
    //     );

    //     // Recalculate offset relative to player
    //     offset = transform.position - player.position;

    //     // Enable follow
    //     isFollowing = true;
    // }
}