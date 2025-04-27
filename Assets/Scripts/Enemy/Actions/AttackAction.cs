using System;
using UnityEngine;

public class AttackAction : AbstractEnemyAction
{
    //[Header("Config")]
    //[SerializeField] private float timeBtwAttacks;

    //private EnemyController enemy;
    //private EnemyAttack enemyWeapon;
    //private float attackTimer;

    //private void Awake()
    //{
    //    enemy = GetComponent<EnemyController>();
    //    enemyWeapon = GetComponent<EnemyController>();
    //}

    //private void Start()
    //{
    //    attackTimer = timeBtwAttacks;
    //}

    public override void Act()
    {
        //if (enemy.Player == null) return;
        //attackTimer -= Time.deltaTime;
        //if (attackTimer <= 0f)
        //{
        //    enemyWeapon.UseWeapon();
        //    attackTimer = timeBtwAttacks;
        //}
        Debug.Log("Attack");
    }
}