using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public float collapseDistance = 2f; // 발판이 무너지는 거리
    public float collapseSpeed = 2f; // 발판이 무너지는 속도
    public float collapseDuration = 2f; // 무너지는 시간
    private Vector3 initialPosition; // 초기 위치
    private bool isPlayerOnPlatform = false; // 플레이어가 발판 위에 있는지 여부
    private bool isCollapsing = false; // 무너지는 중인지 여부
    private float collapseTimer = 0f; // 타이머

    void Start()
    {
        initialPosition = transform.position; // 초기 위치 설정
    }

    void Update()
    {
        if (isCollapsing)
        {
            if (collapseTimer < collapseDuration)
            {
                // 일정 시간 동안 아래로 이동
                transform.Translate(Vector3.down * Time.deltaTime * collapseSpeed);
                collapseTimer += Time.deltaTime;
            }
            else
            {
                // 일정 시간이 지나면 오브젝트 파괴
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollapsing)
        {
            isPlayerOnPlatform = true; // 플레이어가 발판 위에 있음
            isCollapsing = true; // 무너지는 동작 시작
        }
    }
}







