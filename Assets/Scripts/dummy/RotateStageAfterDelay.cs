using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStageAfterDelay : MonoBehaviour
{
    public float rotationSpeed = 10f; // �������� ȸ�� �ӵ�
    private bool isRotating = false;

    private void Start()
    {
        Invoke("RotateStage", 3f); // 3�� �ڿ� RotateStage �Լ� ȣ��
    }

    private void Update()
    {
        if (isRotating)
        {
            // ���������� X ���� �������� ȸ����Ŵ
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right * rotationAmount);

            // ȸ���� �Ϸ�Ǹ� isRotating�� false�� �����Ͽ� �� �̻� ȸ������ �ʵ��� ��
            /*
            if (Mathf.Abs(transform.rotation.eulerAngles.x) >= 90f)
            {
                isRotating = false;
            }
            */
        }
    }

    private void RotateStage()
    {
        isRotating = true; // ȸ�� ����
    }
}



