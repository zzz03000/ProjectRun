using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private float targetRotationX = 0.0f;
    private bool isRotating = false;

    void Start()
    {
        // ���� ���� �� �ʱ� ȸ�� ����
        targetRotationX = 0.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isRotating)
        {
            // P�� ���� ������ 90���� ȸ��
            targetRotationX += 90.0f;
            isRotating = true;
            RotateStage();
        }
        else if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            // O�� ���� ������ -90���� ȸ
            targetRotationX -= 90.0f;
            isRotating = true;
            RotateStage();
        }
    }

    void RotateStage()
    {
        Quaternion targetRotation = Quaternion.Euler(targetRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        StartCoroutine(LerpRotation(targetRotation, rotationSpeed));
    }

    System.Collections.IEnumerator LerpRotation(Quaternion targetRotation, float timeToRotate)
    {
        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0;

        while (elapsedTime < timeToRotate)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, (elapsedTime / timeToRotate));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }
}







