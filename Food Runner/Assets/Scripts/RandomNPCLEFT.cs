using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPCLEFT : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move left
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }
}