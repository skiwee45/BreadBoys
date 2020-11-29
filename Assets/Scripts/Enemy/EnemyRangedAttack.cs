using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class EnemyRangedAttack : MonoBehaviour
{
    public float bulletForce = 1f;
    public float stopDistance;
    private Transform player;
    private EnemyMove enemyMovement;
    public Transform firePoint; //needs another sprite

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;
    private void Start()
    {
        //makes player transform to lock onto
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //sets up ai movement
        enemyMovement = GetComponent<EnemyMove>();
        enemyMovement.enabled = false;
        //sets current bullet reload to shooting rate
        timeBetweenShots = startTimeBetweenShots;
    }
    private void Update()
    {
        //just calls movement function
        Movement();

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
    { //shooting function
        //creates and stores bullet
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        //stores bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //add force to bullet to shoot out
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void Movement()
    {
        //takes care of movement
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            //move towards player (use the ai script)
            enemyMovement.enabled = true;
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            enemyMovement.enabled = false; //disables ai movement
        }
        else
        {
            enemyMovement.enabled = false; //disables ai movement
        }
    }
}
