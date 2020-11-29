using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public float maxHealth;
	public float currentHealth;
	public GameObject dieEffect;
	private float nextBurn;
	public float burnRate = 0.1f;
	private HealthBar hb;
	private bool isBurning = false;
	private Animator anim;

	public AudioSource audioSource;

	// Start is called before the first frame update
	void Start()
	{
		//instantiate variables
		hb = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
		currentHealth = maxHealth;
		hb.SetMaxHealth(maxHealth);
		hb.SetHealth(currentHealth);
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{
			//GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
			//Destroy(effect, 5f);
			FindObjectOfType<GunMove>().drop();
			SceneManager.LoadScene("Preformance");
			Destroy(gameObject);
		}

		if (isBurning) //checks isBurning and if so, calls takefiredamage
        {
			TakeFireDamage();
        }
	}

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
		hb.SetHealth(currentHealth);
		anim.SetTrigger("Hurt");
	}

	public void HealHealth(float healthHealed)
	{
		currentHealth += healthHealed;
		hb.SetHealth(currentHealth);
		if (currentHealth + healthHealed >= 100)
		{
			currentHealth = maxHealth;
		}
	}

	public void TakeFireDamage()
    {
		if (Time.time >= nextBurn) //checks to make sure rate of damage matches burnRate
		{
			audioSource.Play();
			TakeDamage(1);
			nextBurn = Time.time + burnRate;
		}
	}

	public void changeIsBurning(bool burning)
    {
		//change the variable so update knows to call takefiredamage()
		isBurning = burning;
    }
}
