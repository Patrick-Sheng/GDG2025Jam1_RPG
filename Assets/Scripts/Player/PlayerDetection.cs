using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float rangeDetection;
    [SerializeField] private LayerMask obstacleMask;

    public EnemyHealth EnemyTarget { get; set; }

    private CircleCollider2D myCollider2D;
    private List<EnemyHealth> enemyList = new List<EnemyHealth>();
    private List<EnemyHealth> enemiesLineOfSight = new List<EnemyHealth>();

    private void Awake()
    {
        myCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        myCollider2D.radius = rangeDetection;
    }

    private void Update()
    {
        CheckEnemiesInSight();
        GetClosestEnemy();
    }

    private void CheckEnemiesInSight()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList.Count == 0 || enemyList == null) return;
            Vector3 playerPos = transform.position;
            Vector3 dirEnemy = enemyList[i].transform.position - playerPos;
            RaycastHit2D hit = Physics2D.Raycast(playerPos,
                dirEnemy, dirEnemy.magnitude, obstacleMask);
            if (hit.collider == null)
            {
                if (enemiesLineOfSight.Contains(enemyList[i]) == false)
                {
                    enemiesLineOfSight.Add(enemyList[i]);
                }
            }
            else
            {
                if (enemiesLineOfSight.Contains(enemyList[i]))
                {
                    enemiesLineOfSight.Remove(enemyList[i]);
                }

                if (EnemyTarget == enemyList[i])
                {
                    EnemyTarget = null;
                }
            }
        }
    }

    private void GetClosestEnemy()
    {
        float minDistance = Mathf.Infinity;
        EnemyHealth enemyTarget = null;
        for (int i = 0; i < enemiesLineOfSight.Count; i++)
        {
            Vector3 enemyPos = enemiesLineOfSight[i].transform.position;
            float enemyDistance = Vector3.Distance(transform.position, enemyPos);
            if (enemyDistance < minDistance)
            {
                enemyTarget = enemiesLineOfSight[i];
                minDistance = enemyDistance;
            }
        }

        if (enemyTarget != null)
        {
            EnemyTarget = enemyTarget;
            enemiesLineOfSight.Clear();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemyList.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemyList.Contains(enemy))
            {
                enemyList.Remove(enemy);
            }

            if (enemy == EnemyTarget)
            {
                EnemyTarget = null;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        int n = enemyList.Count;
        for (int i = 0; i < n; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, enemyList[i].transform.position);
        }

        if (EnemyTarget == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, EnemyTarget.transform.position);
    }
}
