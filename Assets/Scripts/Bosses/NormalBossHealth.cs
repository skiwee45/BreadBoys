using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NormalBossHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private GameObject healthPickups;

    public event EventHandler BossBattleOver;

    [SerializeField] private BossHealthBar bHB;
    [SerializeField] private GameObject bossBar;
    public GameObject dieEffect;

    public AudioSource audioSource;

    private void Start()
    {
        currentHealth = maxHealth;
        //instantiate the healthbar
        bossBar = GameObject.FindGameObjectWithTag("bHB");
        bHB = bossBar.GetComponent<BossHealthBar>();
        bHB.SetMaxHealth(20);
    }
    void Update()
    {
        if (currentHealth <= 0f)
        {
            audioSource.Play();
            //Die effect
            Debug.Log("boss dead");
            //Invokes the event
            BossBattleOver?.Invoke(this, EventArgs.Empty);
            Instantiate(healthPickups, gameObject.transform.position, Quaternion.identity);
            //plays particle effect
            GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        bHB.DamageTaken(damage);
    }
}
