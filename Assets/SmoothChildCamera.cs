using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SmoothChildCamera : MonoBehaviour
{
    [Tooltip("How long (in seconds) the camera takes to catch up")]
    public float smoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 localOffset;
    private Transform parentTf;

    void Start()
    {
        // remember the parent and the camera's initial local‐offset
        parentTf = transform.parent;
        localOffset = transform.localPosition;
    }

    void LateUpdate()
    {
        if (parentTf == null) return;

        // compute where the camera WOULD be (world space) if it were just
        // sitting at its original localOffset under the (possibly teleported) parent:
        Vector3 desiredWorldPos = parentTf.TransformPoint(localOffset);

        // smooth its actual world‐position toward that desired point
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredWorldPos,
            ref velocity,
            smoothTime
        );
    }
}
