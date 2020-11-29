using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    private Rigidbody2D player;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Vector2 offset; //how far the slingshot is from the player
    private Vector2 mouse; //tracks mouse position
    [SerializeField] private Camera cam;
    private float angle1; //angle from slingshot to mouse
    private bool flipped; //checks if slingshot is on right or left

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mouse = cam.ScreenToWorldPoint(Input.mousePosition); //makes a vector 2 of the mouse position
        if (angle1 > 90 || angle1 < -90) //checks to flip sides or not
        {
            flipped = true;
            offset.x = -0.4f;
        }
        else
        {
            flipped = false;
            offset.x = 0.4f;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(player.position + offset); //makes slingshot follow player

        Vector2 lookDir = mouse - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (flipped)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }
        rb.rotation = angle;
        angle1 = angle;
    }

    public float getAngle()
    {
        return angle1;
    }

    public void drop()
    {
        Destroy(gameObject);
    }
}