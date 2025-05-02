using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionPlayerInSight : AbstractEnemyDecision
{
    [SerializeField] private LayerMask obstacleMask;

    private EnemyController enemy;

    private void Start()
    {
        enemy = GetComponent<EnemyController>();
    }

    public override bool Decide()
    {
        return DetectPlayerInSight(); ;
    }

    private bool DetectPlayerInSight()
    {
        if (enemy.Player == null) return false;
        Vector3 direction = enemy.Player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            direction.normalized, direction.magnitude, obstacleMask);
        if (hit.collider != null)
        {
            return false;
        }

        return true;
    }

    private void OnDrawGizmosSelected()
    {
        if (enemy.Player == null) return;
        Gizmos.color = DetectPlayerInSight() ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, enemy.Player.position);
    }
}
