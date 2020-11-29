using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveEffect : MonoBehaviour
{
    private PlayerHealth health;

    private void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //when enter stove, begins burning
    {
        health = FindObjectOfType<PlayerHealth>();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            health.changeIsBurning(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //when exit stove, stop burning
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            health.changeIsBurning(false);
        }
    }
}
