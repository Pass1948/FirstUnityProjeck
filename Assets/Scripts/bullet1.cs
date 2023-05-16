using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]                   // �ش� ������Ʈ�� �����ϰ� ����

public class bullet1 : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject explosionEffect;


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

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
