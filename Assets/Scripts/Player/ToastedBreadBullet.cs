using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastedBreadBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject trailEffect;
    [SerializeField] private float damage;
    private GameObject effect1;

    private void Start()
    {
        effect1 = Instantiate(trailEffect, transform.position, Quaternion.identity, gameObject.transform);
        
    }

    //colliding script
    public void OnTriggerEnter2D(Collider2D collision)
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
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //particle effect and kills itself
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect1);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
        
    }
}
