using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speedX = 2.0f; // x축 움직이는 속도
    public float speedY = 2.0f; // y축 움직이는 속도
    public float distanceX = 5.0f; // x축으로 이동할 총 거리
    public float distanceY = 3.0f; // y축으로 이동할 총 거리

    private Vector3 originalPosition;
    private float movingDistanceX;
    private float movingDistanceY;

    private int directionX = 1; // x축 방향 설정. 오른쪽으로 이동하기 위해 1로 초기화
    private int directionY = 1; // y축 방향 설정. 위쪽으로 이동하기 위해 1로 초기화

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        // x축으로 움직이는 거리를 업데이트
        movingDistanceX += Mathf.Abs(speedX) * Time.deltaTime;

        // y축으로 움직이는 거리를 업데이트
        movingDistanceY += Mathf.Abs(speedY) * Time.deltaTime;

        // 일정 거리 이동 후 방향 반전
        if (movingDistanceX > distanceX)
        {
            movingDistanceX = 0;
            directionX *= -1; // x축 방향 반전
        }

        if (movingDistanceY > distanceY)
        {
            movingDistanceY = 0;
            directionY *= -1; // y축 방향 반전
        }

        // 이동
        transform.Translate(new Vector3(speedX * directionX * Time.deltaTime, speedY * directionY * Time.deltaTime, 0));
    }
}


