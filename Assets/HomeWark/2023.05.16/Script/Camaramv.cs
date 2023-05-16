using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Camaramv : MonoBehaviour
{
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;

    public void ShowOverheadView()
    {
        camera1.enabled = false;
        camera2.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    private Coroutine camaramvo;
    IEnumerator ShootCamara()
    {
        while (true)
        {
            ShowOverheadView();
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCamaraChange(InputValue value)
    {
        if (value.isPressed)
        {
            camaramvo = StartCoroutine(ShootCamara());
        }
        else
        {
            StopCoroutine(camaramvo);
            ShowFirstPersonView();
        }
    }
}
