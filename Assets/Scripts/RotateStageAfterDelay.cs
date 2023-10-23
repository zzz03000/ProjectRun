using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStageAfterDelay : MonoBehaviour
{
    public float rotationSpeed = 10f; // 스테이지 회전 속도
    private bool isRotating = false;

    private void Start()
    {
        Invoke("RotateStage", 3f); // 3초 뒤에 RotateStage 함수 호출
    }

    private void Update()
    {
        if (isRotating)
        {
            // 스테이지를 X 축을 기준으로 회전시킴
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right * rotationAmount);

            // 회전이 완료되면 isRotating을 false로 설정하여 더 이상 회전하지 않도록 함
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
        isRotating = true; // 회전 시작
    }
}



