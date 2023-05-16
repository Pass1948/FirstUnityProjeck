using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoving : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    public float curlSpeed;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
   

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * curlSpeed * Time.deltaTime, Space.World);
    }

    private void FixedUpdate()
    {
        Rotate();
    }
}
