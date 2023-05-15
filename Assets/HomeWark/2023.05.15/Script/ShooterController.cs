using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    private Vector3 moveDir;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpPower;

    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private float repeatTime;

    private void Update()                       
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * moveDir.z, Space.Self);  
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * moveDir.x, Space.World);
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void OnFire(InputValue value)
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }

    private Coroutine bulletRoutine;
    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
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
