using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInput : MonoBehaviour
{
    /*******************************************************************************
	 * ����Ƽ �Է�
	 * 
	 * ����Ƽ���� ������� ����� ������ �� �ִ� ����
	 * ����ڴ� �ܺ� ��ġ�� �̿��Ͽ� ������ ������ �� ����
	 * ����Ƽ�� �پ��� Ÿ���� �Է±��(Ű���� �� ���콺, ���̽�ƽ, ��ġ��ũ�� ��)�� ����
	 *******************************************************************************/

    private void Update()
    {
        InputByInputManager();
    }


    // <Device> : ���� ����̶� ������ �߾����� ����
    // Ư���� ��ġ�� �������� �Է� ����
    // Ư���� ��ġ�� �Է��� �����ϱ� ������ ���� �÷����� ������ �����
    private void InputByDevice()
    {
        // Ű������ �Է°���
        // GetKey�ø������ bool���� ��������
        if (Input.GetKeyDown(KeyCode.Space))        // ������ ����
            Debug.Log("Space key is down");
        if (Input.GetKey(KeyCode.Space))            // ������ ��
            Debug.Log("Space key is pressing");
        if (Input.GetKeyUp(KeyCode.Space))          // ���� ����
            Debug.Log("Space key is up");

        // ���콺�� �Է°��� (���� 0, ������ 1)
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Mouse left button is down");
        if (Input.GetMouseButton(0))
            Debug.Log("Mouse left button is pressing");
        if (Input.GetMouseButtonUp(0))
            Debug.Log("Mouse left button is up");
    }


    // <InputManager>  : ����ϰ� VR��⿡ ���� ������ ������
    // ���� ��ġ�� �Է��� �Է¸Ŵ����� �̸��� �Է��� ����
    // �Է¸Ŵ����� �̸����� ������ �Է��� ��������� Ȯ��
    // ����Ƽ �������� Edit -> Project Settings -> Input Manager ���� ����


    private void InputByInputManager()
    {
        // ��ư �Է�
        // Fire1 : Ű����(Left Ctrl), ���콺(Left Button), ���̽�ƽ(button0)���� ���ǵ�
        // �̸��� �Է¹����� �ȴ�
        if (Input.GetButtonDown("Fire1"))           // ������ ����
            Debug.Log("Fire1 is down");
        if (Input.GetButton("Fire1"))               // ������ ��
            Debug.Log("Fire1 is pressing");
        if (Input.GetButtonUp("Fire1"))             // ���� ����
            Debug.Log("Fire1 is up");

        // �� �Է�
        // Horizontal(����) : Ű����(a,d / ��, ��), ���̽�ƽ(���� �Ƴ��α׽�ƽ �¿�)
        float x = Input.GetAxis("Horizontal");
        // Vertical(����) : Ű����(w,s / ��, ��), ���̽�ƽ(���� �Ƴ��α׽�ƽ ����)
        float y = Input.GetAxis("Vertical");
        Debug.Log($"{x}, {y}");
    }

    // <InputSystem>
    // Unity 2019.1 ���� �����ϰ� �� �Է¹��
    // ������Ʈ�� ���� �Է��� ��������� Ȯ��
    // GamePad, JoyStick, Mouse, Keyboard, Pointer, Pen, TouchScreen, XR ��� ���� ����

    private void InputByInputSystem()
    {
        // InputSystem�� �Է� ��ÿ� �ش� �Լ��� Ȯ�� �Ǵ� �̺�Ʈ ������� ������
        // Update���� �Էº�������� Ȯ���ϴ� ��� ��� ������ ���� ��� �̺�Ʈ�� Ȯ��
        // �޽����� ���� �޴� ��İ� �̺�Ʈ �Լ��� ���� �����ϴ� ��� ������ ����
    }

    // Move �Է¿� �����ϴ� OnMove �޽��� �Լ�
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        bool isPress = value.isPressed;
    }
}
