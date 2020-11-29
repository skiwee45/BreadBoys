using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenBreadBullet : MonoBehaviour
{
    public GameObject hitEffect;
    [SerializeField] private float damage;
    //colliding script
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<NormalBossHealth>().TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("BossMinion"))
        {
            collision.gameObject.GetComponent<bossMinionHealth>().TakeDamage(damage);
        }
        //slow enemy
        applySlow(collision.gameObject);
        //particle effect and kills itself
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }

    private void applySlow(GameObject enemy)
    {
        if (enemy.GetComponent<EnemyMove>() != null)
        {
            enemy.GetComponent<EnemyMove>().slowEnemyForSeconds(1.5f);
        }
    }
}
