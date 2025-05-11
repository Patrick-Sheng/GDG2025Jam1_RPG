using UnityEngine;

public class CameraRestriction : MonoBehaviour
{
    public Transform player;
    public Vector2 minCameraPos;
    public Vector2 maxCameraPos;
    public float smoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            
            // Smooth follow
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // Clamp to boundaries
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            float clampedX = Mathf.Clamp(smoothPosition.x, minCameraPos.x + camWidth, maxCameraPos.x - camWidth);
            float clampedY = Mathf.Clamp(smoothPosition.y, minCameraPos.y + camHeight, maxCameraPos.y - camHeight);

            transform.position = new Vector3(clampedX, clampedY, smoothPosition.z);
        }
    }
}
