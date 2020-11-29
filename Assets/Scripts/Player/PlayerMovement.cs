using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    private Transform transform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    // Input
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //wasd, controller, arrow keys
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0) { //flips player when moving left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", movement.sqrMagnitude); //controls transition from idle to walk
    }

    //Physics and movement
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //actually moving player
    }

    //slow debuff
    public void slowPlayer() //changes movement speed to 3
    {
        moveSpeed = 3f;
    }

    public void regularspeedPlayer() //changes movement speed back to 5
    {
        Debug.Log("reg speed");
        moveSpeed = 5f;
    }

    public void slowPlayerForSeconds(float seconds) //changes movement speed to 3 then back to 5
    {
        StartCoroutine(slow(seconds));
    }

    IEnumerator slow(float seconds)
    {
        moveSpeed = 3f;
        yield return new WaitForSeconds(seconds);
        moveSpeed = 5f;
    }
}
