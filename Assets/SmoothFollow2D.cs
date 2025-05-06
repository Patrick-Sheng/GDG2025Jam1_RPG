
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SmoothFollow2D : MonoBehaviour
{
    [Tooltip("What the camera should track (usually the Player).")]
    public Transform target;

    [Tooltip("How long it takes (in seconds) to catch up. Lower = snappier.")]
    [Min(0f)]
    public float smoothTime = 0.15f;

    [Tooltip("Cameratotarget offset. Z should stay negative so the camera is in front of the scene.")]
    public Vector3 offset = new Vector3(0f, 0f, -10f);


    private Vector3 _velocity;

    void Awake()
    {

        if (target == null)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) target = player.transform;
        }
    }

    void LateUpdate()
    {
        if (target == null) return; 


        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref _velocity,
            smoothTime
        );
    }
}