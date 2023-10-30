using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float rotationSpeed = 5.0f;
    private float targetRotationZ = 0.0f;
    private bool isRotating = false;

    [SerializeField]
    private float rotateCoolTime = 1f;
    [SerializeField]
    private bool canRotate;

    private void Awake()
    {
        // ���� ���� �� �ʱ� ȸ�� ����
        targetRotationZ = 0.0f;
        canRotate = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isRotating & canRotate)
        {
            // P�� ���� ������ 90���� ȸ��
            targetRotationZ += 90.0f;
            isRotating = true;
            RotateStage();
        }
        else if (Input.GetKeyDown(KeyCode.O) && !isRotating & canRotate)
        {
            // O�� ���� ������ -90���� ȸ
            targetRotationZ -= 90.0f;
            isRotating = true;
            RotateStage();
        }
    }

    private void RotateStage()
    {
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, targetRotationZ);
        StartCoroutine(LerpRotation(targetRotation, rotationSpeed));
        StartCoroutine(RotateCoolTime());
    }

    private IEnumerator LerpRotation(Quaternion targetRotation, float timeToRotate)
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

    private IEnumerator RotateCoolTime() 
    {
        canRotate = false;
        yield return new WaitForSeconds(rotateCoolTime);
        canRotate = true;
    }
}







