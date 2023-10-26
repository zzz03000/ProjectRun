using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigid;

    private float speed = 12f;
    [SerializeField]
    [Header("Current Speed")]
    private float forwardSpeed = 1f;
    private float maxSpeed = 10f;
    private float jumpForce = 8f;
    private float horizontal;

    private bool isJumping;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundChecker;
    private float groundCheckDistance = 0.1f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveToFront();

        Jump();
    }

    private void MoveToFront()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (forwardSpeed <= maxSpeed)
            forwardSpeed += Time.deltaTime;
        else
            forwardSpeed = maxSpeed;

        Vector3 velocity = new Vector3(horizontal, 0, forwardSpeed);
        velocity *= speed;
        velocity.y = rigid.velocity.y;
        rigid.velocity = velocity;
    }

    private void Jump()
    {
        if (IsGround())
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rigid.velocity = new Vector3(rigid.velocity.x, jumpForce, rigid.velocity.z);

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rigid.velocity.y > 0f)
        {
            coyoteTimeCounter = 0f;
        }
    }

    private void Stop()
    {
        rigid.velocity = Vector3.zero;
    }

    private bool IsGround()
    {
        RaycastHit hit;
        return Physics.Raycast(groundChecker.position, Vector3.down, out hit, groundCheckDistance);
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
}
