using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirePoint : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    public Rigidbody2D parent;
    private Vector2 targetPosition; //tracks mouse position
    private float angle1; //angle from slingshot to mouse

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //makes the vector2 target always player position
        targetPosition = player.position;
    }
    void FixedUpdate()
    {
        //creates vector2 pointing to target
        Vector2 lookDir = targetPosition - rb.position;
        //creates angle to point at
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //points at angle
        rb.rotation = angle;
        angle1 = angle;

        //makes sure always following parent
        rb.MovePosition(parent.position);
    }

    public float getAngle()
    {
        return angle1;
    }
}