using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMinionHealth : MonoBehaviour
{
	[SerializeField] private float maxHealth;
	[SerializeField] private float currentHealth;
	public GameObject dieEffect;


	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{
			//GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
			//Destroy(effect, 5f);

			//destroy himself
			Destroy(gameObject);
		}
	}

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
	}
}
