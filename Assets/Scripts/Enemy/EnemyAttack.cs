using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public float attackRate = 1f;
    public float damage = 5;
    float nextAttackTime;

    private void Start()
    {
        damage = FindObjectOfType<GameManager>().getEnemyDamage();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (GetComponent<EnemyMove>().getReachedEnd())
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
            }
        }
    }
    void Attack()
    {
        //play animation
        //anim.SetTrigger("Attack");
        //detect player in attack
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        //deal damage
        foreach (Collider2D player in hitPlayers)
        {
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
