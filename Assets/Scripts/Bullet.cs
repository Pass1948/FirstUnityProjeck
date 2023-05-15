using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]                   // �ش� ������Ʈ�� �����ϰ� ����

public class BulletMv : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = transform.forward * bulletSpeed;  // �Ѿ��� �ٶ󺸴� z�������� ���󰡰� ����
        Destroy(gameObject, 5f);                        // �Ѿ��� 5�ʵ� ���ŵǰ� ����
    }
}
