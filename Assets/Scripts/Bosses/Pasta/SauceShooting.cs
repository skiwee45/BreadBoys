using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceShooting : MonoBehaviour
{
    public float bulletForce = 1f;
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;

    private void Start()
    {
        //sets current bullet reload to shooting rate
        timeBetweenShots = startTimeBetweenShots;
    }

    private void Update()
    {
        //shooting if statements
        if (timeBetweenShots <= 0)
        {
            Shoot();
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
        GameObject bullet3 = Instantiate(projectile, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(firePoint2.right * bulletForce, ForceMode2D.Impulse);

        GameObject bullet5 = Instantiate(projectile, firePoint3.position, firePoint3.rotation);
        Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
        rb5.AddForce(-firePoint3.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet7 = Instantiate(projectile, firePoint4.position, firePoint4.rotation);
        Rigidbody2D rb7 = bullet7.GetComponent<Rigidbody2D>();
        rb7.AddForce(-firePoint4.right * bulletForce, ForceMode2D.Impulse);
    }
}
