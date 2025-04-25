using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform attackFixedPoint;
    

    [Header("Melee Attack")]
    [SerializeField] private GameObject melee;
    [SerializeField] private float meleeCooldown = 0.5f;
    private float lastMeleeTime;

    [Header("Laser Attack")]
    [SerializeField] private LaserAttack laser;
    [SerializeField] private float laserCooldown = 0.01f;
    [SerializeField] private int laserDamage;
    private float lastLaserTime;

    private PlayerInput playerInput;
    private InputAction meleeAction;
    private InputAction laserAction;
    private PlayerDetection detection;
    private PlayerController playerController;

    [Header("Laser Config")]
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private float laserWidth = 1f;
    [SerializeField] private float maxLaserLength = 100f; // Distance where laser becomes invisible
    [SerializeField] private LayerMask collisionLayers;

    private void Awake()
    {
        detection = GetComponentInChildren<PlayerDetection>();
        playerInput = GetComponent<PlayerInput>();
        meleeAction = playerInput.actions["Melee"];
        laserAction = playerInput.actions["Ranged"];
        

    }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        laserLine.startWidth = laserWidth;
        laserLine.endWidth = laserWidth;
    }

    private void Update()
    {
        if (meleeAction.triggered && Time.time >= lastMeleeTime + meleeCooldown)
        {
            StartCoroutine(MeleeAttack());
        }

        if (laserAction.triggered && Time.time >= lastLaserTime + laserCooldown)
        {
            //StartCoroutine(LaserAttack());
            lastLaserTime = Time.time;
            DrawLaser();
        }
    }

    private GameObject meleeObject;
    private IEnumerator MeleeAttack()
    {
      
        lastMeleeTime = Time.time;
        meleeObject = Instantiate(melee, attackPoint.position, Quaternion.identity, attackFixedPoint);
        if (detection.EnemyTarget != null)
        {
            Vector3 dirToEnemy = detection.EnemyTarget.transform.position - attackPoint.position;
            float angle = Mathf.Atan2(-dirToEnemy.y, -dirToEnemy.x) * Mathf.Rad2Deg;
            meleeObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else // Default to player's facing direction
        {
            Vector2 playerInput = playerController.GetInput();
            float angle = Mathf.Atan2(-playerInput.y, -playerInput.x) * Mathf.Rad2Deg;
            meleeObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(meleeObject);
        
    }
    private void LaserAttack(Vector2 direction)
    {
        lastMeleeTime = Time.time;
        LaserAttack laserObject = Instantiate(laser);
        laserObject.transform.position = attackPoint.position;
        laserObject.Direction = direction;
        laserObject.Damage = laserDamage;
        
    }


    private void DrawLaser()
    {   

        Vector2 direction = playerController.GetInput().normalized; // Ensure unit vector
        if (detection.EnemyTarget != null)
        {
            direction = detection.EnemyTarget.transform.position - attackPoint.position;

        }
        LaserAttack(direction);
        RaycastHit2D hit = Physics2D.Raycast(
            attackPoint.position,
            direction,
            maxLaserLength,
            collisionLayers
        );

        float laserLength = hit.collider ? hit.distance : maxLaserLength;


        laserLine.SetPosition(0, attackPoint.position);
        laserLine.SetPosition(1, (Vector2)attackPoint.position + direction * laserLength);
        laserLine.enabled = true;

        StartCoroutine(HideLaserAfterDelay(0.5f));
        
    }

    private IEnumerator HideLaserAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        laserLine.enabled = false;
    }
}
