using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonix : Monster
{
    private GameObject player;
    private Rigidbody2D rbPlayer;
    private List<Vector2> directionVector2 = new List<Vector2>();

    // Start is called before the first frame update
    protected override void Start()
    {
        // call Start() in super class Monster
        base.Start();
        speed = 3;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        directionVector2.Add(Vector2.right);
        directionVector2.Add(Vector2.up);
        directionVector2.Add(Vector2.left);
        directionVector2.Add(Vector2.down);
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {

        // move towards player
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            rbPlayer = player.GetComponent<Rigidbody2D>();
        }
        if (player != null)
        {
            MoveRandomPlayer();
        }

        
    }
    private void MoveRandomPlayer()
    {
        float deltaX = rbPlayer.position.x - rb.position.x;
        float deltaY = rbPlayer.position.y - rb.position.y;
        int twoSides = Random.Range(0, 2);
        if (twoSides == 0)
        {
            ChooseDirectionRightOrLeft(deltaX);
        }
        else
        {
            ChooseDirectionUpOrDown(deltaY);
        }
        rb.MovePosition(rb.position + directionVector2[direction] * speed * Time.deltaTime);
    }
    private void MoveTowardsGargoyle()
    {
        float deltaX = rbPlayer.position.x - rb.position.x;
        float deltaY = rbPlayer.position.y - rb.position.y;
        // Move in x- och y-direction. Take longest differance first.
        if (System.Math.Abs(deltaX) < System.Math.Abs(deltaY))
        {
            // move in y-direction
            if (deltaY > 0)
            {
                direction = 1;
                // up - check for obstacle
                RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.5f, Vector2.up, 0.2f);
                if (hit.transform != null)
                {
                    // object in direction => move in x-direction
                    ChooseDirectionRightOrLeft(deltaX);
                }
            }
            else
            {
                direction = 3;
                // down - check for obstacle
                RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.down * 0.5f, Vector2.down, 0.2f);
                if (hit.transform != null)
                {
                    // object in direction => move in x-direction
                    ChooseDirectionRightOrLeft(deltaX);
                }
            }

        }
        else
        {
            // move in x-direction
            if (deltaX > 0)
            {
                direction = 0;
                // right - check for obstacle
                RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.right * 0.5f, Vector2.right, 0.2f);
                if (hit.transform != null)
                {
                    // object to the right 
                    ChooseDirectionUpOrDown(deltaY);
                }
            }
            else
            {
                direction = 2;
                // left - check for obstacle
                RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.left * 0.5f, Vector2.left, 0.2f);
                if (hit.transform != null)
                {
                    // object to the right 
                    ChooseDirectionUpOrDown(deltaY);
                }
            }
        }
        rb.MovePosition(rb.position + directionVector2[direction] * speed * Time.deltaTime);
        //SnapToGrid();
    }
    private void ChooseDirectionUpOrDown(float deltaY)
    {
        if (deltaY > 0)
        {
            direction = 1;
        }
        else
        {
            direction = 3;
        }

    }
    private void ChooseDirectionRightOrLeft(float deltaX)
    {
        if (deltaX > 0)
        {
            direction = 0;
        }
        else
        {
            direction = 2;
        }
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        SnapToGrid();
    }
    protected override void OnCollisionStay2D(Collision2D collision)
    {
        SnapToGrid();
    }
   
}
