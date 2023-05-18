using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Vector3 moveDir;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    // [SerializeField] private float jumpPower;

    private void Update()
    {
        Move();
        Rotate();
        // LookAt();
        // transform.position = new Vector3(0, 0, 0);  // 지정대상 또는 좌표로 순간이동 시킬수있음

    }
    public void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * moveDir.z, Space.Self);  // Translate는 원하는 방향으로 몇 힘으로 몇프레임정도로 움직이는걸로 이뤄짐
                                                                                                // 좌표 뒤에 추가로 Space.World or Space.Self를 써주면 주체를 결정할수있다
                                                                                                // transform.position += moveDir* speed * Time.deltaTime;          
                                                                                                // position는 좌표로 움직임(상하좌우)
                                                                                                // deltaTime은 1/시간 의 단위로 이뤄져있다
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * moveDir.x, Space.World);

    }

    /* 
    public void LookAt()        // 지정된 대상을 바라보며 움직임
    {
        transform.LookAt(new Vector3(0, 0, 0));                 // 목표를 지점 또는 지정대상을 설정해주면 된다
    }
    */

    /*
    public void Rotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 rotation = transform.rotation.eulerAngles();
    }
    */

    /*
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    */

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;

    }

    /*
    private void OnJump(InputValue value)
    {
        Jump();
    }
    */

}
