using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ToasterShooting : MonoBehaviour
{
    public float bulletForce;
    public Transform firePoint;

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
        //creates and stores bullet
        firePoint.gameObject.GetComponent<ToasterFirePoint>().changeAngle(Random.Range(-12, 13));
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        //stores bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //add force to bullet to shoot out
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
