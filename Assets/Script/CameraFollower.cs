
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

    // Force camera to snap instantly to player position
    public void SnapToPlayer()
    {
        if (player == null) return;

        Vector3 targetPos = player.position + offset;
        targetPos.z = -10;

        transform.position = targetPos;
    }

    // Recalculate offset (VERY IMPORTANT)
    public void ResetOffset()
    {
        if (player == null) return;

        offset = transform.position - player.position;
    }

    // Initialize camera correctly (BEST METHOD)
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

}