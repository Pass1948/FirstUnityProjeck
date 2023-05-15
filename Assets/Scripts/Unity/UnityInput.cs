using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInput : MonoBehaviour
{
    /*******************************************************************************
	 * 유니티 입력
	 * 
	 * 유니티에서 사용자의 명령을 감지할 수 있는 수단
	 * 사용자는 외부 장치를 이용하여 게임을 제어할 수 있음
	 * 유니티는 다양한 타입의 입력기기(키보드 및 마우스, 조이스틱, 터치스크린 등)를 지원
	 *******************************************************************************/

    private void Update()
    {
        InputByInputManager();
    }


    // <Device> : 고전 방식이라 요즘은 잘쓰이지 않음
    // 특정한 장치를 기준으로 입력 감지
    // 특정한 장치의 입력을 감지하기 때문에 여러 플랫폼에 대응이 어려움
    private void InputByDevice()
    {
        // 키보드의 입력감지
        // GetKey시리즈들은 bool형을 갖고있음
        if (Input.GetKeyDown(KeyCode.Space))        // 누르는 순간
            Debug.Log("Space key is down");
        if (Input.GetKey(KeyCode.Space))            // 누르는 중
            Debug.Log("Space key is pressing");
        if (Input.GetKeyUp(KeyCode.Space))          // 때는 순간
            Debug.Log("Space key is up");

        // 마우스의 입력감지 (왼쪽 0, 오른족 1)
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Mouse left button is down");
        if (Input.GetMouseButton(0))
            Debug.Log("Mouse left button is pressing");
        if (Input.GetMouseButtonUp(0))
            Debug.Log("Mouse left button is up");
    }


    // <InputManager>  : 모바일과 VR기기에 대한 대응이 부족함
    // 여러 장치의 입력을 입력매니저에 이름과 입력을 정의
    // 입력매니저의 이름으로 정의한 입력의 변경사항을 확인
    // 유니티 에디터의 Edit -> Project Settings -> Input Manager 에서 관리


    private void InputByInputManager()
    {
        // 버튼 입력
        // Fire1 : 키보드(Left Ctrl), 마우스(Left Button), 조이스틱(button0)으로 정의됨
        // 이름을 입력받으면 된다
        if (Input.GetButtonDown("Fire1"))           // 누르는 순간
            Debug.Log("Fire1 is down");
        if (Input.GetButton("Fire1"))               // 누르는 중
            Debug.Log("Fire1 is pressing");
        if (Input.GetButtonUp("Fire1"))             // 때는 순간
            Debug.Log("Fire1 is up");

        // 축 입력
        // Horizontal(수평) : 키보드(a,d / ←, →), 조이스틱(왼쪽 아날로그스틱 좌우)
        float x = Input.GetAxis("Horizontal");
        // Vertical(수직) : 키보드(w,s / ↑, ↓), 조이스틱(왼쪽 아날로그스틱 상하)
        float y = Input.GetAxis("Vertical");
        Debug.Log($"{x}, {y}");
    }

    // <InputSystem>
    // Unity 2019.1 부터 지원하게 된 입력방식
    // 컴포넌트를 통해 입력의 변경사항을 확인
    // GamePad, JoyStick, Mouse, Keyboard, Pointer, Pen, TouchScreen, XR 기기 등을 지원

    private void InputByInputSystem()
    {
        // InputSystem은 입력 당시에 해당 함수가 확인 되는 이벤트 방식으로 구현됨
        // Update마다 입력변경사항을 확인하는 방식 대신 변경이 있을 경우 이벤트로 확인
        // 메시지를 통해 받는 방식과 이벤트 함수를 직접 연결하는 방식 등으로 구성
    }

    // Move 입력에 반응하는 OnMove 메시지 함수
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        bool isPress = value.isPressed;
    }
}
