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
        // transform.position = new Vector3(0, 0, 0);  // ������� �Ǵ� ��ǥ�� �����̵� ��ų������

    }
    public void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * moveDir.z, Space.Self);  // Translate�� ���ϴ� �������� �� ������ �������������� �����̴°ɷ� �̷���
                                                                                                // ��ǥ �ڿ� �߰��� Space.World or Space.Self�� ���ָ� ��ü�� �����Ҽ��ִ�
                                                                                                // transform.position += moveDir* speed * Time.deltaTime;          
                                                                                                // position�� ��ǥ�� ������(�����¿�)
                                                                                                // deltaTime�� 1/�ð� �� ������ �̷����ִ�
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * moveDir.x, Space.World);

    }

    /* 
    public void LookAt()        // ������ ����� �ٶ󺸸� ������
    {
        transform.LookAt(new Vector3(0, 0, 0));                 // ��ǥ�� ���� �Ǵ� ��������� �������ָ� �ȴ�
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
