using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSpawner : MonoBehaviour
{
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;

    void Start()
    {
        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            Spawn();
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    void Spawn()
    {
        Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
    }
}
