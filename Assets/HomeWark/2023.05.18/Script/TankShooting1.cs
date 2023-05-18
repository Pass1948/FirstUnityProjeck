using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TankShooting1 : MonoBehaviour
{
    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private float repeatTime;

    public UnityEvent OnFired;                              
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        animator.SetTrigger("Fire");

        GameManager.Data.AddShootCount(1);
    }
    private void OnFire(InputValue value)
    {
        Fire();
        OnFired?.Invoke();                               
    }

    private Coroutine bulletRoutine;
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
