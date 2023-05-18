using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    
    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private float repeatTime;

    public UnityEvent OnFired;                              // �߻� ���� �̺�Ʈ �߰�
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Fire()
    {
        // Prefab�� ���ο� ���ӿ�����Ʈ�� ����� �۾�
        // GameObject odj = Instantiate(bulletPrefab, transform.position, transform.rotation);    
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        animator.SetTrigger("Fire");

        GameManager.Data.AddShootCount(1);
    }
    private void OnFire(InputValue value)
    {
        Fire();
        OnFired?.Invoke();                                // ��������� Inspectorâ���� �߰�����   
    }

    private Coroutine bulletRoutine;
    // �ݺ������� �Ѿ��� ��� ��� ����, ������Ű�� ������ ������ ���簡 ��
    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            animator.SetTrigger("Fire");
            GameManager.Data.AddShootCount(1);
            yield return new WaitForSeconds(repeatTime);

        }

    }

    private void OnRepeatFire(InputValue value)
    {
        if (value.isPressed)
        {
            bulletRoutine = StartCoroutine(BulletMakeRoutine());

        }
        else
        {
            StopCoroutine(bulletRoutine);
        }
    }


}
