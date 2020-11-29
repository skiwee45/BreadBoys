using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoggyBreadBullet : MonoBehaviour
{
    public GameObject hitEffect;
    [SerializeField] private float damage;
    public Transform attackPoint;
    public float attackRange = 0.3f;
    public LayerMask enemyLayers;
    //colliding script
    public void OnCollisionEnter2D(Collision2D collision)
    {
        AOE();
        //water effect to show range
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    private void AOE()
    {
        //detect enemies in attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //deal damage
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.CompareTag("Enemy"))
            {
                enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            else if (enemy.gameObject.CompareTag("Boss"))
            {
                enemy.gameObject.GetComponent<NormalBossHealth>().TakeDamage(damage);
            }
            else if (enemy.gameObject.CompareTag("BossMinion"))
            {
                enemy.gameObject.GetComponent<bossMinionHealth>().TakeDamage(damage);
            }
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
