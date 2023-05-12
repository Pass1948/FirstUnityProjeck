using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMoveing : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    public float speed;
    public float curlSpeed;
    public float jumpPower;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    void Move() 
    {
        rb.AddForce(moveDir * speed);
        //transform.position += moveDir * speed * Time.deltaTime;
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

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Move();
        
    }

}
