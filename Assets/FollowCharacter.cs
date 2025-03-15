using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player or character to follow
    public Vector3 offset = new Vector3(0, 10, 0); // Camera offset
    public float smoothSpeed = 0.125f; // How smoothly the camera follows the player

    void LateUpdate()
    {
        if (target != null)
        {
            // Smoothly move the camera towards the target's position
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}