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

    [Header("Obstacle Detection")]
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float detectionRange;

    private Vector3 movePosition;
    private Vector3 moveDirection;
    private float lastMoveTime;
    private float moveCooldown = 5;
    private float lastAttackTime = 0;

    private BossAttackInterface[] attacks;
    private int id;
    private bool isAttackInProgress;

    void Start()
    {
        // Initialize the attacks array
        attacks = new BossAttackInterface[3];
        attacks[0] = GetComponent<BossLaser>();
        attacks[1] = GetComponent<BossProjectile>();
        attacks[2] = GetComponent<BossSpecial>();
    }

    void Update()
    {
        attemptAttacking();

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Debug.Log(attacks[1].isAttacking);
        //    attacks[1].Attack();
        //    Debug.Log(attacks[1].isAttacking);
        //}
        attemptMoving();
    }

    private bool isAttacking()
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
        if (!isAttacking()&&lastAttackTime+attackCooldown<Time.time)
        {
            id = Random.Range(0, attacks.Length);
            if (attacks[id] != null)
            {
                attacks[id].Attack();
                //Debug.Log("Executing attack: " + attacks[id].GetType().Name);
            }

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
        Collider2D collider = Physics2D.OverlapCircle(transform.position,
            detectionRange, obstacleLayer);
        if (collider != null)
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
}