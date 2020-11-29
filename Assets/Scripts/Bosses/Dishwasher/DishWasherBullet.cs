using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishWasherBullet : MonoBehaviour
{
    public GameObject hitEffect;
    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.SetRotation(rb.rotation + 90);
    }
    //colliding script
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
