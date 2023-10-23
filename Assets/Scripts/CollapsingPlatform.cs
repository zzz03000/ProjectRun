using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public float collapseDistance = 2f; // ������ �������� �Ÿ�
    public float collapseSpeed = 2f; // ������ �������� �ӵ�
    private Vector3 initialPosition; // �ʱ� ��ġ
    private bool isPlayerOnPlatform = false; // �÷��̾ ���� ���� �ִ��� ����

    void Start()
    {
        initialPosition = transform.position; // �ʱ� ��ġ ����
    }

    void Update()
    {
        if (isPlayerOnPlatform)
        {
            // �÷��̾ ���� ���� ���� �� ������ �Ʒ��� �̵���Ŵ
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
            isPlayerOnPlatform = true; // �÷��̾ ���� ���� ����
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false; // �÷��̾ ���� ������ ���
        }
    }
}




