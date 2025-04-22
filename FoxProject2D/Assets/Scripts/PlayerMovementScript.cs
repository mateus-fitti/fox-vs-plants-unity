using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    Animator animator;

    Rigidbody2D rb;

    Vector2 movement;

    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.magnitude != 0.0f)
        {
            animator.SetBool("moving", true);
            animator.SetFloat("axis_X", movement.x);
            animator.SetFloat("axis_Y", movement.y);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    // FixedUpdate é chamado de acordo com a frequência definida no sistema de física
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
