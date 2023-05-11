using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReport : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float power = 0;                  


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        name = "Player";
        rigidbody.AddForce(Vector3.up * power, ForceMode.Impulse);
    }

}
