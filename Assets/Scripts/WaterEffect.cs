using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterEffect : MonoBehaviour
{
    private PlayerMovement move;

    private void Start()
    {
        //instantiate variables
        move = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //when enter water, begin slow effect
    {
        move = FindObjectOfType<PlayerMovement>();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            move.slowPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //when exit water, end slow effect
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            move.regularspeedPlayer();
        }
    }
}
