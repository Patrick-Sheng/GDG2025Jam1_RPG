using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private GameObject laserImpactEffect;
    [SerializeField] private SpriteRenderer playerSprite;
    

    [Header("Melee Attack")]
    [SerializeField] private GameObject melee;
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
    private PlayerDetection detection;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        meleeAction = playerInput.actions["Melee"];
        laserAction = playerInput.actions["Ranged"];
        //playerSprite = GetComponent<SpriteRenderer>();
        laserLine.enabled = false;
        detection = GetComponentInChildren<PlayerDetection>();

    }

    private void Update()
    {
        //AutoAim();

        if (meleeAction.triggered && Time.time >= lastMeleeTime + meleeCooldown)
        {
            StartCoroutine(MeleeAttack());
        }

        if (laserAction.triggered && Time.time >= lastLaserTime + laserCooldown)
        {
            StartCoroutine(LaserAttack());
        }
    }
    //private void AutoAim()
    //{
    //    if (detection.EnemyTarget != null)
    //    {
    //        Vector3 dirToEnemy = detection.EnemyTarget.transform.position -
    //                             transform.position;
    //        Rotate(dirToEnemy);
    //    }
    //}
    //protected void Rotate(Vector3 direction)
    //{
    //    anim.SetFloat("X", direction.x);
    //    anim.SetFloat("Y", direction.y);
    //}

    private GameObject meleeObject;
    private IEnumerator MeleeAttack()
    {
      
        lastMeleeTime = Time.time;
        meleeObject = Instantiate(melee, attackPoint);
        yield return new WaitForSeconds(0.5f);
        Destroy(meleeObject);
        
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
