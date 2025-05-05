using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;

public class BossController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject player;
    [SerializeField] private float attackCooldown;

    [SerializeField] private float wanderSpeed;
    [SerializeField] private Vector2 moveRange;
    [SerializeField] private float minDistanceCheck = 0.5f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject SoulPrefab;
    [SerializeField] private GameObject AngelPrefab;

    [Header("Obstacle Detection")]
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float detectionRange;

    private Vector3 movePosition;
    private Vector3 moveDirection;
    private float lastMoveTime;
    private float moveCooldown = 5;
    private float lastAttackTime = 0;
    private Rigidbody2D rb;
    private bool banAttack;
    private float adsSpawnCooldown = 20;
    private float lastAdsSpawnTime;

    private BossAttackInterface[] attacks;
    private int id;
    private bool isAttackInProgress;
    private bool isMoving;
    private bool banMovement;

    void Start()
    {
        banAttack = false;
        rb = GetComponent<Rigidbody2D>();
        attacks = new BossAttackInterface[3];
        attacks[0] = GetComponent<BossLaser>();
        attacks[1] = GetComponent<BossProjectile>();
        attacks[2] = GetComponent<BossSpecial>();
        banMovement = false;
        lastAdsSpawnTime = 0;
        SpawnAds();


    }

    void Update()
    {
        attemptAttacking();

        attemptMoving();

        if(lastAdsSpawnTime+adsSpawnCooldown < Time.time)
        {
            SpawnAds();
        }
            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    Debug.Log(attacks[1].isAttacking);
            //    attacks[1].Attack();
            //    Debug.Log(attacks[1].isAttacking);
            //}

    }
    private void SpawnAds()
    {
        Instantiate(SoulPrefab, transform.position, Quaternion.identity);
        Instantiate(AngelPrefab, transform.position, Quaternion.identity);
        lastAdsSpawnTime = Time.time;
    }
    public bool IsMoving()
    {
        return rb.linearVelocity.magnitude > 0;
    }
    public bool isAttacking()
    {
        foreach (var attack in attacks)
        {
            if (attack != null && attack.isAttacking)
            {
                lastAttackTime = Time.time;
                return true;
            }
        }
        return false;
    }

    private void attemptAttacking()
    {
        if (!isAttacking()&&lastAttackTime+attackCooldown<Time.time&&!banAttack)
        {
            id = Random.Range(0, attacks.Length);
            attacks[id].Attack();         
        }
    }
    private void attemptMoving()
    {
        if (Time.time > lastMoveTime + moveCooldown)
        {
            moveDirection = (movePosition - transform.position).normalized;
            transform.Translate(moveDirection * (wanderSpeed * Time.deltaTime));

        }
        if (CanGetNewPosition())
        {
            lastMoveTime = Time.time;
            GetNewMoveDirection();
        }
    }
    private bool CanGetNewPosition()
    {
        if (Vector3.Distance(transform.position, movePosition) < minDistanceCheck)
        {
            return true;
        }

        // Raycast that ignores projectiles
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            moveDirection,
            detectionRange,
            obstacleLayer & ~enemyLayer // This excludes projectile layer
        );

        // Debug visualization (obstacles = red, projectiles = green)
        Debug.DrawRay(transform.position, moveDirection * detectionRange,
                     hit.collider ? Color.red : Color.green);
        if (hit.collider != null && hit.collider.GetComponentInParent<EnergyOrb>() == null)
        {
            
            Vector3 oppositeDirection = -moveDirection;
            transform.position += oppositeDirection * 0.1f;
            return true;
        }

        return false;
    }
    private void GetNewMoveDirection()
    {

        movePosition = transform.position + GetRandomDirection();

    }
    private Vector3 GetRandomDirection()
    {
        float randomX = Random.Range(-moveRange.x, moveRange.x);
        float randomY = Random.Range(-moveRange.y, moveRange.y);
        return new Vector3(randomX, randomY);
    }
    public void ResetAllStates()
    {

        // Cancel any delayed invokes
        CancelInvoke();
        banAttack = true;
    }
}