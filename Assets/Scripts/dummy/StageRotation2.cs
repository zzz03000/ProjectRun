using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotation2 : MonoBehaviour
{
    public GameObject stage; // 스테이지 전체를 나타내는 부모 오브젝트
    public GameObject player; // 플레이어 오브젝트

    private string currentOrientation = "Floor";
    private bool isRotating = false;
    private Quaternion targetRotation;
    private float rotationSpeed = 100.0f; // 조정 가능한 회전 속도


    private void Update()
    {
        if (isRotating)
        {
            // 여기에 회전 속도를 조정할 수 있는 로직을 추가할 수 있습니다.
            float step = rotationSpeed * Time.deltaTime;
            stage.transform.rotation = Quaternion.RotateTowards(stage.transform.rotation, targetRotation, step);
            player.GetComponent<Rigidbody>().useGravity = false;

            if (stage.transform.rotation == targetRotation)
            {
                isRotating = false;
                player.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            if (currentOrientation == "RightWall")
                RotateStage(90);
            else if (currentOrientation == "LeftWall")
                RotateStage(-90);

            AdjustPlayerPosition(currentOrientation, "Floor");
            currentOrientation = "Floor";
        }
        else if (collision.gameObject.name == "RightWall")
        {
            if (currentOrientation == "Floor")
                RotateStage(90);
            else if (currentOrientation == "Ceiling")
                RotateStage(-90);

            AdjustPlayerPosition(currentOrientation, "RightWall");
            currentOrientation = "RightWall";
        }
        else if (collision.gameObject.name == "LeftWall")
        {
            if (currentOrientation == "Floor")
                RotateStage(-90);
            else if (currentOrientation == "Ceiling")
                RotateStage(90);

            AdjustPlayerPosition(currentOrientation, "LeftWall");
            currentOrientation = "LeftWall";
        }
        else if (collision.gameObject.name == "Ceiling")
        {
            if (currentOrientation == "RightWall")
                RotateStage(-90);
            else if (currentOrientation == "LeftWall")
                RotateStage(90);

            AdjustPlayerPosition(currentOrientation, "Ceiling");
            currentOrientation = "Ceiling";
        }
    }

    private void RotateStage(float xAngle)
    {
        player.GetComponent<Rigidbody>().useGravity = false;

        targetRotation = stage.transform.rotation * Quaternion.Euler(xAngle, 0, 0);
        isRotating = true;

        player.GetComponent<Rigidbody>().useGravity = true;
    }

    private void AdjustPlayerPosition(string oldOrientation, string newOrientation)
    {
        Vector3 stageLocalDisplacement = Vector3.zero;
        Vector3 playerGlobalDisplacement = Vector3.zero;

        // 스테이지의 로컬 변위 계산
        if (oldOrientation == "Floor" && newOrientation == "RightWall")
        {
            stageLocalDisplacement = Quaternion.Euler(-90, 0, 0) * player.transform.localPosition;
        }
        else if (oldOrientation == "Floor" && newOrientation == "LeftWall")
        {
            stageLocalDisplacement = Quaternion.Euler(90, 0, 0) * player.transform.localPosition;
        }
        else if (oldOrientation == "RightWall" && newOrientation == "Floor")
        {
            stageLocalDisplacement = Quaternion.Euler(90, 0, 0) * player.transform.localPosition;
        }
        else if (oldOrientation == "LeftWall" && newOrientation == "Floor")
        {
            stageLocalDisplacement = Quaternion.Euler(-90, 0, 0) * player.transform.localPosition;
        }

        // 전역 변위 계산
        playerGlobalDisplacement = stage.transform.TransformVector(stageLocalDisplacement);
        //player.transform.position += playerGlobalDisplacement;
        //player.transform.parent = null;
    }
}




