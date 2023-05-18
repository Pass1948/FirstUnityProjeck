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

    public UnityEvent OnFired;                              // 발사 과련 이벤트 추가
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Fire()
    {
        // Prefab을 새로운 게임오브젝트로 만드는 작업
        // GameObject odj = Instantiate(bulletPrefab, transform.position, transform.rotation);    
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        animator.SetTrigger("Fire");

        GameManager.Data.AddShootCount(1);
    }
    private void OnFire(InputValue value)
    {
        Fire();
        OnFired?.Invoke();                                // 여러기능을 Inspector창에서 추가가능   
    }

    private Coroutine bulletRoutine;
    // 반복적으로 총알을 쏘는 기능 구현, 지정된키를 누르고 있으면 연사가 됨
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
