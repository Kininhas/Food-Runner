using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5f; // Velocidade do personagem

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Obter entrada de movimento horizontal e vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular o vetor de movimento  
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed;

        // Aplicar movimento ao Rigibody
        rb.velocity = movement;
    }
}
