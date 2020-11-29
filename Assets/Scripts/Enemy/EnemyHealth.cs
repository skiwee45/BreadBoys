using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] private float maxHealth;
	[SerializeField] private float currentHealth;
	public GameObject dieEffect;
	private EnemySpawn enemySpawn;
	public AudioSource audioSource;


	// Start is called before the first frame update
	void Start()
	{
		maxHealth = FindObjectOfType<GameManager>().getEnemyHealth();
		currentHealth = maxHealth;
		enemySpawn = GetComponent<EnemySpawn>();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{
			//GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
			//Destroy(effect, 5f);
			audioSource.Play();
			//let enemyspawn know that enemy has died
			enemySpawn.enemyDeath();
			gameObject.SetActive(false);
		}
	}

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
	}
}
