using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterFirePoint : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    public Rigidbody2D parent;
    private Vector2 targetPosition; //tracks player position
    private int offset;

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
        rb.rotation = angle + offset;


        //makes sure always following parent
        rb.MovePosition(parent.position);
    }

    public void changeAngle(int offset)
    {
        this.offset = offset;
    }
}