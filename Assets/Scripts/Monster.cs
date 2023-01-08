using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Actor
{
    // directions
    // 0 - right
    // 1 - up
    // 2 - left
    // 3 - down
    protected int direction = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        // call Start in super class Actor
        base.Start();
        speed = 10;
    }


    // Update is called once per physics update
    protected virtual void FixedUpdate()
    {
        if (direction == 0)
        {
            // right
            rb.MovePosition(rb.position + new Vector2(speed, 0) * Time.deltaTime);
        }
        else if (direction == 1)
        {
            // up
            rb.MovePosition(rb.position + new Vector2(0, speed) * Time.deltaTime);
        }
        else if (direction == 2)
        {
            // left
            rb.MovePosition(rb.position + new Vector2(-speed, 0) * Time.deltaTime);
        }
        else if (direction == 3)
        {
            // down
            rb.MovePosition(rb.position + new Vector2(0, -speed) * Time.deltaTime);
        }

    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        SelectDirection();
        SnapToGrid();
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        SelectDirection();
        SnapToGrid();
    }
    protected virtual void SelectDirection()
    { 
        // Do nothing
        // override in sub class
    }
    protected void SnapToGrid()
    {
        if (direction == 0 || direction == 2)
        {
            // moving right or left
            SnapToGridY();
        }
        else
        {
            // moving up or down
            SnapToGridX();
        }
    }
    protected void SnapToGridX()
    {
        rb.position = new Vector2((float)System.Math.Round(rb.position.x), rb.position.y);
    }
    protected void SnapToGridY()
    {
        rb.position = new Vector2(rb.position.x, (float)System.Math.Round(rb.position.y));
    }
}
