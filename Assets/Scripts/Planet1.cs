using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet1 : MonoBehaviour
{
    private float rotateAngle = 0f;
    private float selfRotateAngle = 0f;
    public float selfRotateSpeed = 0f; // 행성 자전속도
    public float planetSpeed = 0f;  // 공전속도 임의 지정
    
    private float rotateRadius = 1.0f;


    void Start()
    {
        rotateRadius = transform.localPosition.x;
        Debug.Log(rotateRadius);
    }

   
    void Update()
    {
        float rotateSpeed = selfRotateSpeed / planetSpeed; // 지구의 공전 각속도

        // get desired position
        float xPos = rotateRadius * Mathf.Cos(rotateAngle);
        float zPos = rotateRadius * Mathf.Sin(rotateAngle);

        transform.localPosition = new Vector3(xPos, 34.29f, zPos);

        rotateAngle += rotateSpeed * Time.deltaTime;

        selfRotateAngle = selfRotateSpeed * Time.deltaTime;

        //이 메서드는 시계방향으로 회전시키므로 selfRotateAngle을 음수로 설정
        transform.Rotate(Vector3.up, -selfRotateAngle);
    }
}
