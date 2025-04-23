using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private GameObject laserImpactEffect;

    [Header("Melee Attack")]
    [SerializeField] private float meleeRange = 0.5f;
    [SerializeField] private int meleeDamage = 20;
    [SerializeField] private float meleeCooldown = 0.5f;
    private float lastMeleeTime;

    [Header("Laser Attack")]
    [SerializeField] private float laserRange = 10f;
    [SerializeField] private int laserDamage = 10;
    [SerializeField] private float laserCooldown = 1f;
    [SerializeField] private float laserDuration = 0.1f;
    private float lastLaserTime;
    private bool isLaserActive;

    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;

    private PlayerInput playerInput;
    private InputAction meleeAction;
    private InputAction laserAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        meleeAction = playerInput.actions["Melee"];
        laserAction = playerInput.actions["Ranged"];
        spriteRenderer = GetComponent<SpriteRenderer>();
        laserLine.enabled = false;
    }

    private void Update()
    {
        AutoAim();

        if (meleeAction.triggered && Time.time >= lastMeleeTime + meleeCooldown)
        {
            MeleeAttack();
        }

        if (laserAction.triggered && Time.time >= lastLaserTime + laserCooldown)
        {
            StartCoroutine(LaserAttack());
        }
    }

    private void AutoAim()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, laserRange, enemyLayers);
        float closestDist = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestEnemy = enemy.transform;
            }
        }

        currentTarget = closestEnemy;

        // Face the target or default direction
        if (currentTarget != null)
        {
            spriteRenderer.flipX = currentTarget.position.x < transform.position.x;
        }
    }

    private void MeleeAttack()
    {
        lastMeleeTime = Time.time;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, meleeRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(meleeDamage);
        }
    }

    private IEnumerator LaserAttack()
    {
        lastLaserTime = Time.time;
        laserLine.enabled = true;

        Vector2 fireDirection;
        Vector2 endPoint;

        // Auto-aim if target exists, otherwise fire forward
        if (currentTarget != null)
        {
            endPoint = currentTarget.position;
            fireDirection = (endPoint - (Vector2)attackPoint.position).normalized;
        }
        else
        {
            fireDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;
            endPoint = (Vector2)attackPoint.position + fireDirection * laserRange;
        }

        laserLine.SetPosition(0, attackPoint.position);
        laserLine.SetPosition(1, endPoint);

        // Damage check
        RaycastHit2D hit = Physics2D.Raycast(
            attackPoint.position,
            fireDirection,
            laserRange,
            enemyLayers
        );

        if (hit.collider != null)
        {
            hit.collider.GetComponent<EnemyHealth>()?.TakeDamage(laserDamage);
            Instantiate(laserImpactEffect, hit.point, Quaternion.identity);
        }

        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, laserRange);
    }
}
