using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Actor : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float speed = 5;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // prevent physics engine to rotate Actor
        rb.freezeRotation = true;
        // gravity has no effect on Actor
        rb.gravityScale = 0;
    }
}
