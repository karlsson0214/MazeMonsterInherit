using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    // Start is called before the first frame update
    protected override void Start()
    {
        // call Start() in super class Actor
        base.Start();
        tag = "Player"; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // left
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            // right
            rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            // up
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey (KeyCode.S))
        {
            // down
            rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            // stop gargoyle from moving when idle and hit by a moving object
            rb.velocity = Vector2.zero;
        }
        
    }
}
