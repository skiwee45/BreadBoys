using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBoss : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public float attackRate = 0.8f;
    public float damage = 9;
    float nextAttackTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (GetComponent<EnemyMove>().getReachedEnd())
            {
                Attack();
                Debug.Log("Enemy Attack");
                nextAttackTime = Time.time + attackRate;
            }
        }
    }
    void Attack()
    {
        //detect player in attack
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        //deal damage
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("damage done");
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}