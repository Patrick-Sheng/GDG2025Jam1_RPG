using UnityEngine;
using System.Collections;

public class LaserAttack : MonoBehaviour
{
    [Header("Laser Config")]
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private float laserWidth = 0.1f;
    [SerializeField] private float maxLaserLength = 100f; // Distance where laser becomes invisible
    [SerializeField] private LayerMask collisionLayers;

    [Header("Reference")]
    [SerializeField] private GameObject player;

    private PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        laserLine.startWidth = laserWidth;
        laserLine.endWidth = laserWidth;
    }

    private void Update()
    {
        Vector2 facingDirection = playerController.GetInput();
        DrawLaser(facingDirection);
    }

    private void DrawLaser(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxLaserLength, collisionLayers);
        float laserLength = hit.collider != null ? hit.distance : maxLaserLength;

        laserLine.SetPosition(0, transform.position);
        laserLine.SetPosition(1, (Vector2)transform.position + direction * laserLength);


    }
}
