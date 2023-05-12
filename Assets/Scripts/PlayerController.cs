using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;

    [SerializeField]
    public float movePower;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public float jumpPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotate();
        //LookAt();
        Jump();
    }

    private void Move()
    {
        rb.AddForce(transform.forward * moveDir.z * movePower);
        transform.position += moveDir * movePower * Time.deltaTime; // Time.deltaTime은 1ms로 움직임을 가질수있게 해줌
        //transform.Translate(Vector3.forward * moveDir.z * movePower * Time.deltaTime, Space.World);
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * moveSpeed * Time.deltaTime, Space.World);
    }

    public void LookAt()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }

    public void Rotation()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 rotation = transform.rotation.ToEulerAngles();
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }


    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void OnJump(InputValue value)
    {
        Jump();
    }
}
