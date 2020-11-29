using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeBullet : MonoBehaviour
{
    public GameObject hitEffect;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
            col.gameObject.GetComponent<PlayerMovement>().slowPlayerForSeconds(1.5f);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
