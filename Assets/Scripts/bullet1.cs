using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]                   // 해당 컴포넌트를 의존하게 설정

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
        rb.velocity = transform.forward * bulletSpeed;  // 총알이 바라보는 z방향으로 날라가게 설정
        Destroy(gameObject, 5f);                        // 총알이 5초뒤 제거되게 설정
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
