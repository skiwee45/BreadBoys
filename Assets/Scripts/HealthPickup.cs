using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	public AudioSource audioSource;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			col.gameObject.GetComponent<PlayerHealth>().HealHealth(15);
			audioSource.Play();
			Destroy(gameObject);
		}
	}
}
