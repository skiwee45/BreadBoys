using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropsShoot : MonoBehaviour
{
    public float bulletForce;
    public Transform firePoint;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;

    public ToasterFirePoint tFP;

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
        Debug.Log("Dishwasher shot");
        //creates and stores bullet
        firePoint.gameObject.GetComponent<ToasterFirePoint>().changeAngle(Random.Range(-5, 6));
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        //stores bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //add force to bullet to shoot out
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
