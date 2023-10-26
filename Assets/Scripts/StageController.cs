using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float rotationSpeed = 5.0f;
    private float targetRotationX = 0.0f;
    private bool isRotating = false;

    private float rotateCoolTime = 3f;
    [SerializeField]
    private bool canRotate;

    private void Awake()
    {
        // ���� ���� �� �ʱ� ȸ�� ����
        targetRotationX = 0.0f;
        canRotate = true;
    }

    private void Update()
    {
        if(isRotating)
            player.GetComponent<Rigidbody>().useGravity = false;
        else
            player.GetComponent<Rigidbody>().useGravity = true;

        if (Input.GetKeyDown(KeyCode.P) && !isRotating & canRotate)
        {
            // P�� ���� ������ 90���� ȸ��
            targetRotationX += 90.0f;
            isRotating = true;
            RotateStage();
        }
        else if (Input.GetKeyDown(KeyCode.O) && !isRotating & canRotate)
        {
            // O�� ���� ������ -90���� ȸ
            targetRotationX -= 90.0f;
            isRotating = true;
            RotateStage();
        }
    }

    private void RotateStage()
    {
        Quaternion targetRotation = Quaternion.Euler(targetRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
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







