using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet1 : MonoBehaviour
{
    private float rotateAngle = 0f;
    private float selfRotateAngle = 0f;
    public float selfRotateSpeed = 0f; // �༺ �����ӵ�
    public float planetSpeed = 0f;  // �����ӵ� ���� ����
    
    private float rotateRadius = 1.0f;


    void Start()
    {
        rotateRadius = transform.localPosition.x;
        Debug.Log(rotateRadius);
    }

   
    void Update()
    {
        float rotateSpeed = selfRotateSpeed / planetSpeed; // ������ ���� ���ӵ�

        // get desired position
        float xPos = rotateRadius * Mathf.Cos(rotateAngle);
        float zPos = rotateRadius * Mathf.Sin(rotateAngle);

        transform.localPosition = new Vector3(xPos, 34.29f, zPos);

        rotateAngle += rotateSpeed * Time.deltaTime;

        selfRotateAngle = selfRotateSpeed * Time.deltaTime;

        //�� �޼���� �ð�������� ȸ����Ű�Ƿ� selfRotateAngle�� ������ ����
        transform.Rotate(Vector3.up, -selfRotateAngle);
    }
}
