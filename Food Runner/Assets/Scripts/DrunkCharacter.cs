using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkCharacter : MonoBehaviour
{
    public float detectionRadius = 3f;
    public float attackDistance = 2f;
    public float attackDelay = 1f;
    public Animator animator;

    private GameObject Player;
    private bool isAttacking = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAttacking)
        {
            float distance = Vector2.Distance(transform.position, Player.transform.position);

            if (distance <= detectionRadius && distance <= attackDistance)
            {
                isAttacking = true;
                animator.SetTrigger("Attack");

                Invoke("PerformAttack", attackDelay);
            }
        }
    }

    private void PerformAttack()
    {
        Debug.Log("Personagem atacou o player!");
        isAttacking = false;
    }
}
