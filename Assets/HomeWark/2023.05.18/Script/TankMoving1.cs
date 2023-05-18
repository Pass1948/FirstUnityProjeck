using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoving1 : MonoBehaviour
{
    private Vector3 moveDir;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;

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
}
