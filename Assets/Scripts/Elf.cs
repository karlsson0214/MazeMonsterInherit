using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Elf : Monster
{

    // Start is called before the first frame update
    protected override void Start()
    {
        // call Start() in super class Monster
        base.Start();
        CircleCollider2D collider = GetComponent<CircleCollider2D>();        
    }

    protected override void SelectDirection()
    {
        SelectDirection(FreeDirections());
    }
    private void SelectDirection(List<int> noObjectDirections)
    {
        if (noObjectDirections.Count > 0)
        {
            // New random direction, but possible to move in that direction.
            int randomIndex = Random.Range(0, noObjectDirections.Count);
            direction = noObjectDirections[randomIndex];
        }
        else
        {
            // new random direction
            int deltaDirection = Random.Range(1, 3); // 1, 2 or 3
            direction += deltaDirection;
            direction = direction % 4;
        }
    }
    private List<int> FreeDirections()
    {
        // search for direction with no obstacle
        // choose one of these directions randomly
        List<int> noObjectDirections = new List<int>();
        // right - check for object
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.right * 0.5f, Vector2.right, 0.2f);
        if (hit.transform == null)
        {
            //Debug.Log("object to the right at x: " + hit.transform.position.x);
            noObjectDirections.Add(0);
        }

        // up - check for object
        hit = Physics2D.Raycast(rb.position + Vector2.up * 0.5f, Vector2.up, 0.2f);
        if (hit.transform == null)
        {
            //Debug.Log("object to the right at x: " + hit.transform.position.x);
            noObjectDirections.Add(1);
        }
        // left - check for object
        hit = Physics2D.Raycast(rb.position - Vector2.right * 0.5f, -Vector2.right, 0.2f);
        // object to right
        if (hit.transform == null)
        {
            //Debug.Log("object to the right at x: " + hit.transform.position.x);
            noObjectDirections.Add(2);
        }
        // down - check for object
        hit = Physics2D.Raycast(rb.position - Vector2.up * 0.5f, -Vector2.up, 0.2f);
        if (hit.transform == null)
        {
            //Debug.Log("object to the right at x: " + hit.transform.position.x);
            noObjectDirections.Add(3);
        }

        // Debug empty directions
        string debugDirections = "empty directions: ";
        foreach(int direction in noObjectDirections)
        {
            debugDirections += direction + ", ";
        }
        Debug.Log(debugDirections);

        return noObjectDirections;
    }

}
