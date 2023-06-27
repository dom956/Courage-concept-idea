using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    private bool isWalking;
    private bool isRunning;
    private bool isJumping;
    private bool isGrounded;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get player input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");
        bool runInput = Input.GetButton("Run");

        // Update movement and animation based on input
        MoveCharacter(horizontalInput, runInput);
        CheckJump(jumpInput);
        UpdateAnimation();
    }

    private void MoveCharacter(float horizontalInput, bool runInput)
    {
        // Calculate movement speed based on running input
        float currentMoveSpeed = moveSpeed;
        if (runInput)
        {
            currentMoveSpeed *= 1.5f; // Increase the move speed when running
        }

        // Move the character horizontally
        rb.velocity = new Vector2(horizontalInput * currentMoveSpeed, rb.velocity.y);

        // Flip the character sprite if moving left
        if (horizontalInput < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (horizontalInput > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void CheckJump(bool jumpInput)
    {
        if (jumpInput && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
    }

    private void UpdateAnimation()
    {
        // Determine animation states based on player input and grounded check
        isWalking = !isRunning && !isJumping && Mathf.Abs(Input.GetAxis("Horizontal")) > 0f;
        isRunning = !isJumping && Input.GetButton("Run") && Mathf.Abs(Input.GetAxis("Horizontal")) > 0f;

        // Update the animator parameters
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);

        if (isJumping && rb.velocity.y < 0.1f)
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
        }
    }

    private void FixedUpdate()
    {
        // Update the grounded check
        isGrounded = IsGrounded();
    }

    private bool IsGrounded()
    {
        // Cast a box-shaped raycast downwards to check if the character is touching the ground
        float raycastDistance = 0.1f;
        Vector2 raycastOrigin = transform.position - new Vector3(0f, GetComponent<BoxCollider2D>().bounds.extents.y);

        RaycastHit2D hit = Physics2D.BoxCast(raycastOrigin, GetComponent<BoxCollider2D>().size, 0f, Vector2.down, raycastDistance);

        return hit.collider != null;
    }
}
