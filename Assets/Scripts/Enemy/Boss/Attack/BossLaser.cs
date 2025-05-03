using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [Header("Laser Settings")]
    [SerializeField] private float chargeTime = 2f;
    [SerializeField] private float laserDuration = 3f;
    [SerializeField] private int laserDamage = 10;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private LineRenderer laserWarningPrefab;
    [SerializeField] private LineRenderer laserEffectPrefab;

    private Transform player;
    private bool isCharging;
    private bool isFiring;
    private Vector2[] lockedDirections = new Vector2[3];
    private LineRenderer[] warningLasers = new LineRenderer[3];
    private LineRenderer[] activeLasers = new LineRenderer[3];

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void FireLasers()
    {
        if (!isCharging && !isFiring)
        {
            StartCoroutine(LaserSequence());
        }
    }

    private System.Collections.IEnumerator LaserSequence()
    {
        // Phase 1: Charging and showing warning
        isCharging = true;

        // Lock directions at start (won't track player after this)
        lockedDirections[0] = (player.position - transform.position).normalized;
        lockedDirections[1] = Quaternion.Euler(0, 0, 30) * lockedDirections[0];
        lockedDirections[2] = Quaternion.Euler(0, 0, -30) * lockedDirections[0];

        // Create warning lasers
        for (int i = 0; i < 3; i++)
        {
            warningLasers[i] = Instantiate(laserWarningPrefab, transform.position, Quaternion.identity);
            UpdateLaserVisual(warningLasers[i], lockedDirections[i], Color.red);
        }

        float chargeTimer = 0;
        while (chargeTimer < chargeTime)
        {
            chargeTimer += Time.deltaTime;

            // Pulse effect during charge
            float pulse = Mathf.PingPong(chargeTimer * 5f, 0.5f) + 0.5f;
            foreach (var laser in warningLasers)
            {
                if (laser != null)
                {
                    laser.startWidth = pulse * 0.2f;
                    laser.endWidth = pulse * 0.2f;
                }
            }

            yield return null;
        }

        // Phase 2: Firing actual lasers
        isCharging = false;
        isFiring = true;

        // Destroy warning lasers
        foreach (var laser in warningLasers)
        {
            if (laser != null) Destroy(laser.gameObject);
        }

        // Create actual lasers
        for (int i = 0; i < 3; i++)
        {
            activeLasers[i] = Instantiate(laserEffectPrefab, transform.position, Quaternion.identity);
            UpdateLaserVisual(activeLasers[i], lockedDirections[i], Color.yellow);

            // Damage check
            CheckLaserHit(lockedDirections[i]);
        }

        // Keep lasers active for duration
        float fireTimer = 0;
        while (fireTimer < laserDuration)
        {
            fireTimer += Time.deltaTime;
            yield return null;
        }

        // Clean up
        foreach (var laser in activeLasers)
        {
            if (laser != null) Destroy(laser.gameObject);
        }

        isFiring = false;
    }

    private void UpdateLaserVisual(LineRenderer laser, Vector2 direction, Color color)
    {
        laser.positionCount = 2;
        laser.startColor = color;
        laser.endColor = color;

        // Cast ray to find obstacle
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 100f, obstacleLayer);
        float distance = hit.collider != null ? hit.distance : 100f;

        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, (Vector2)transform.position + direction * distance);
    }

    private void CheckLaserHit(Vector2 direction)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, 100f);

        foreach (var hit in hits)
        {
            // Stop at first obstacle
            if (((1 << hit.collider.gameObject.layer) & obstacleLayer) != 0)
            {
                break;
            }

            // Damage player if hit
            if (hit.collider.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(laserDamage);
                }
                // Don't break - laser continues through player
            }
        }
    }
}