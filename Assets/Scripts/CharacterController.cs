using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigid;

    private float speed = 5f;
    [SerializeField] [Header("Current Speed")]
    private float forwardSpeed = 1f;
    private float maxSpeed = 20f;
    private float jumpForce = 8f;
    private float horizontal;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveToFront();

        if (Input.GetButtonDown("Jump") && rigid.velocity.y == 0)
            Jump();
    }

    private void MoveToFront() 
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (forwardSpeed <= maxSpeed)
        {
            forwardSpeed += Time.deltaTime;
        }
        else
            forwardSpeed = maxSpeed;

        Vector3 velocity = new Vector3(horizontal, 0, forwardSpeed);
        velocity *= speed;
        velocity.y = rigid.velocity.y;
        rigid.velocity = velocity;
    }

    private void Jump() 
    {
        rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Stop() 
    {
        rigid.velocity = Vector3.zero;
    }
}
