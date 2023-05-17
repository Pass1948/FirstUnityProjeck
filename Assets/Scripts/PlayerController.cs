using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /* <On+함수의 역할>
     * 
     * On뒤에 붙은 함수들과 그냥 함수들은 내용에 따라 사용방법이 달라지며 
     * 분리객체지향에 따라 사용해주는걸 지향한다 
     * 
     * OnMove  : 입력 input
     * 
     * Move    : 처리 controller
     * 
     * OnMoved : 데이터 model + 이벤트
     * 
     */


    private Animator animator;
    private Vector3 moveDir;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
   // [SerializeField] private float jumpPower;

    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private Transform bulletPoint2;
    [SerializeField] private Transform bulletPoint3;
    [SerializeField] private float repeatTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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

    public void Fire()
    {
        // Prefab을 새로운 게임오브젝트로 만드는 작업
        // GameObject odj = Instantiate(bulletPrefab, transform.position, transform.rotation);    
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        Instantiate(bulletPrefab, bulletPoint2.position, bulletPoint2.rotation);
        Instantiate(bulletPrefab, bulletPoint3.position, bulletPoint3.rotation);
        animator.SetTrigger("Fire");
    }
    private void OnFire(InputValue value)
    {
        Fire();
    }

    private Coroutine bulletRoutine;
    // 반복적으로 총알을 쏘는 기능 구현, 지정된키를 누르고 있으면 연사가 됨
    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            Instantiate(bulletPrefab, bulletPoint2.position, bulletPoint2.rotation);
            Instantiate(bulletPrefab, bulletPoint3.position, bulletPoint3.rotation);
            animator.SetTrigger("Fire");
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
