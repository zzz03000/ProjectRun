using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigid;

    private float speed = 12f;
    [SerializeField]
    [Header("Current Speed")]
    private float forwardSpeed = 1f;
    private float maxSpeed = 15f;
    private float jumpForce = 8f;
    private float horizontal;

    [SerializeField]
    private bool isJumping;

    private float coyoteTime = 0.4f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.4f;
    private float jumpBufferCounter;

    private float jumpCoolTime = 0.4f;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundChecker;
    private float groundCheckDistance = 1.1f;

    private bool isDead = false;
    public bool IsDead => isDead;

    public float Horizontal => horizontal;
    public float YVelocity => rigid.velocity.y;

    private void Awake()
    {
        isDead = false;
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveToFront();

        Jump();

        if(transform.position.y < -30f)
            Dead();
    }

    private void MoveToFront()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (forwardSpeed <= maxSpeed)
            forwardSpeed += (Time.deltaTime / 5);
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

        if (Input.GetButtonUp("Jump") && rigid.velocity.y > 0)
        {
            coyoteTimeCounter = 0f;
        }
    }

    private bool IsGround()
    {
        RaycastHit hit;
        Debug.DrawRay(groundChecker.position, Vector3.down * groundCheckDistance, Color.red);
        Debug.Log(Physics.Raycast(groundChecker.position, Vector3.down, out hit, groundCheckDistance));
        return Physics.Raycast(groundChecker.position, Vector3.down, out hit, groundCheckDistance);
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(jumpCoolTime);
        isJumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Dead();
        }
    }

    private void Dead() 
    {
        isDead = true;
    }
}
