using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
    [SerializeField] private int waveNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //player has entered trigger area
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }

    public int getWaveNumber()
    {
        return waveNumber;
    }
}
