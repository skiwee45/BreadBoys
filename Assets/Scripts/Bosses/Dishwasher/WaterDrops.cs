using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WaterDrops : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public GameObject hitEffect;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<PlayerHealth>().TakeDamage(5);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("BottomScreenCollider"))
        {
            Destroy(gameObject);
        }
    }
}
