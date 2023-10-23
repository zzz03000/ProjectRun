using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public float collapseDistance = 2f; // 발판이 무너지는 거리
    public float collapseSpeed = 2f; // 발판이 무너지는 속도
    private Vector3 initialPosition; // 초기 위치
    private bool isPlayerOnPlatform = false; // 플레이어가 발판 위에 있는지 여부

    void Start()
    {
        initialPosition = transform.position; // 초기 위치 설정
    }

    void Update()
    {
        if (isPlayerOnPlatform)
        {
            // 플레이어가 발판 위에 있을 때 발판을 아래로 이동시킴
            transform.Translate(Vector3.down * Time.deltaTime * collapseSpeed);
        }
        if (transform.position.y < initialPosition.y - collapseDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true; // 플레이어가 발판 위에 있음
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false; // 플레이어가 발판 위에서 벗어남
        }
    }
}




