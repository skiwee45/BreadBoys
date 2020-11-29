using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GunShoot : MonoBehaviour
{
    public Transform firePoint; //where it shoots out from
    public GameObject bulletPrefab; //prefabbed ammo
    public float bulletForce = 1f;
    public float attackRate = 1f;
    private float nextAttackTime;
    private Camera cam;
    private ScreenShakeController screenShake;

    public AudioSource audioSource;

    void Start()
    {
        cam = (Camera)FindObjectOfType(typeof(Camera));
        screenShake = cam.GetComponent<ScreenShakeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                nextAttackTime = Time.time + attackRate;
            }
        }

    }

    private void Shoot()
    { //shooting function
        screenShake.StartShake(.1f, .9f);
        audioSource.Play();
        //creates and stores bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //stores bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //add force to bullet to shoot out
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
