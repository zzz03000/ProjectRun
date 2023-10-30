using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public float collapseDistance = 2f; // ������ �������� �Ÿ�
    public float collapseSpeed = 2f; // ������ �������� �ӵ�
    public float collapseDuration = 2f; // �������� �ð�
    private Vector3 initialPosition; // �ʱ� ��ġ
    private bool isPlayerOnPlatform = false; // �÷��̾ ���� ���� �ִ��� ����
    private bool isCollapsing = false; // �������� ������ ����
    private float collapseTimer = 0f; // Ÿ�̸�

    void Start()
    {
        initialPosition = transform.position; // �ʱ� ��ġ ����
    }

    void Update()
    {
        if (isCollapsing)
        {
            if (collapseTimer < collapseDuration)
            {
                // ���� �ð� ���� �Ʒ��� �̵�
                transform.Translate(Vector3.down * Time.deltaTime * collapseSpeed);
                collapseTimer += Time.deltaTime;
            }
            else
            {
                // ���� �ð��� ������ ������Ʈ �ı�
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollapsing)
        {
            isPlayerOnPlatform = true; // �÷��̾ ���� ���� ����
            isCollapsing = true; // �������� ���� ����
        }
    }
}







