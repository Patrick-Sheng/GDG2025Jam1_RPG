using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerConfig playerConfig;

    private void Update()
    {
        //TBD
    }

    private int middleground;

    //public void RecoverHealth(int amount)
    //{
    //    middleground = amount + playerConfig.CurrentHealth;
    //    if (middleground > )
    //}

    public void TakeDamage(int amount)
    {
        if (playerConfig.CurrentHealth > 0f)
        {
            playerConfig.CurrentHealth -= amount;
        }
    }

    private void PlayerDead()
    {
        Destroy(gameObject);
    }
}
