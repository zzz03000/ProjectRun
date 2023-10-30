using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speedX = 2.0f; // x�� �����̴� �ӵ�
    public float speedY = 2.0f; // y�� �����̴� �ӵ�
    public float distanceX = 5.0f; // x������ �̵��� �� �Ÿ�
    public float distanceY = 3.0f; // y������ �̵��� �� �Ÿ�

    private Vector3 originalPosition;
    private float movingDistanceX;
    private float movingDistanceY;

    private int directionX = 1; // x�� ���� ����. ���������� �̵��ϱ� ���� 1�� �ʱ�ȭ
    private int directionY = 1; // y�� ���� ����. �������� �̵��ϱ� ���� 1�� �ʱ�ȭ

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        // x������ �����̴� �Ÿ��� ������Ʈ
        movingDistanceX += Mathf.Abs(speedX) * Time.deltaTime;

        // y������ �����̴� �Ÿ��� ������Ʈ
        movingDistanceY += Mathf.Abs(speedY) * Time.deltaTime;

        // ���� �Ÿ� �̵� �� ���� ����
        if (movingDistanceX > distanceX)
        {
            movingDistanceX = 0;
            directionX *= -1; // x�� ���� ����
        }

        if (movingDistanceY > distanceY)
        {
            movingDistanceY = 0;
            directionY *= -1; // y�� ���� ����
        }

        // �̵�
        transform.Translate(new Vector3(speedX * directionX * Time.deltaTime, speedY * directionY * Time.deltaTime, 0));
    }
}


