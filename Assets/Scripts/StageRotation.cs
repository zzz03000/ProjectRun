using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotation : MonoBehaviour
{
    public float rotationSpeed = 90f; // 스테이지 회전 속도
    public Transform playerTransform; // 플레이어 캐릭터의 Transform 컴포넌트

    private bool isRotating = false;
    private bool isCollidingRight = false;
    private bool isCollidingLeft = false;
    private bool isCeilingRight = false; // 천장이 오른쪽 벽인지 여부
    private bool isCeilingLeft = false; // 천장이 왼쪽 벽인지 여부
    private bool isFloorRight = false; // 바닥이 오른쪽 벽인지 여부
    private bool isFloorLeft = false; // 바닥이 왼쪽 벽인지 여부

    private void Update()
    {
        if (isRotating)
        {
            float step = rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.identity;
            if (isCollidingRight)
            {
                if (isCeilingRight || isFloorRight)
                {
                    targetRotation = Quaternion.Euler(0f, 0f, 90f);
                }
                else
                {
                    targetRotation = Quaternion.Euler(0f, 0f, -90f);
                }
            }
            else if (isCollidingLeft)
            {
                if (isCeilingLeft || isFloorLeft)
                {
                    targetRotation = Quaternion.Euler(0f, 0f, -90f);
                }
                else
                {
                    targetRotation = Quaternion.Euler(0f, 0f, 90f);
                }
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

            // 플레이어 캐릭터의 회전 업데이트
            if (playerTransform != null)
            {
                playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, targetRotation, step);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))
        {
            isRotating = true;
            isCollidingRight = true;
            isCollidingLeft = false;
        }
        else if (collision.gameObject.CompareTag("LeftWall"))
        {
            isRotating = true;
            isCollidingLeft = true;
            isCollidingRight = false;
        }
        else if (collision.gameObject.CompareTag("Ceiling"))
        {
            if (isCollidingRight)
            {
                isCeilingRight = true;
                isCeilingLeft = false;
            }
            else if (isCollidingLeft)
            {
                isCeilingLeft = true;
                isCeilingRight = false;
            }
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            if (isCollidingRight)
            {
                isFloorRight = true;
                isFloorLeft = false;
            }
            else if (isCollidingLeft)
            {
                isFloorLeft = true;
                isFloorRight = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightWall") || collision.gameObject.CompareTag("LeftWall"))
        {
            isRotating = false;
            isCollidingRight = false;
            isCollidingLeft = false;
        }
        else if (collision.gameObject.CompareTag("Ceiling"))
        {
            isCeilingRight = false;
            isCeilingLeft = false;
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            isFloorRight = false;
            isFloorLeft = false;
        }
    }
}






