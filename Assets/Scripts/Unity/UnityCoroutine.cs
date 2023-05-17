using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
    /************************************************************************
	 * �ڷ�ƾ (Coroutine)
	 * 
	 * �۾��� �ټ��� �����ӿ� �л��� �� �ִ� �񵿱�� �۾� (������Ʈ�� ������ ��ü������ �۵���)
	 * �ݺ������� �۾��� �л��Ͽ� �����ϸ�, ������ �Ͻ������ϰ� �ߴ��� �κк��� �ٽý����� �� ����
	 * ��, �ڷ�ƾ�� �����尡 �ƴϸ� �ڷ�ƾ�� �۾��� ������ ���� �����忡�� ����
	 ************************************************************************/
    // ����� : ����ڰ� ���� ��Ʈ��
    // �񵿱�� : ���α׷��� ������ �۾�


    private void Start()
    {
        StartCoroutine(SubRoutine());
    }

    // <�ڷ�ƾ ����>
    // �ݺ������� �۾��� StartCorouine�� ���� ����

    IEnumerator SubRoutine()
    {

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);    // �ݺ��� 1�� ������ ����
            Debug.Log($"{i}�� ����");
        }
    }

    private Coroutine routine;
    private void CoroutineStart()
    {
        routine = StartCoroutine(SubRoutine()); 
    }

    // <�ڷ�ƾ ����>
    // StopCoroutine�� ���� ���� ���� �ڷ�ƾ ����
    // StopAllCoroutine�� ���� ���� ���� ��� �ڷ�ƾ ����
    // �ݺ������� �۾��� ��� �Ϸ�Ǿ��� ��� �ڵ� ����
    // �ڷ�ƾ�� �����Ų ��ũ��Ʈ�� ��Ȱ��ȭ�� ��� �ڵ� ����

    private void CoroutineStop()
    {
        StopCoroutine(routine);     // ������ �ڷ�ƾ ����
        StopAllCoroutines();        // ��� �ڷ�ƾ ����
    }

    // <�ڷ�ƾ �ð� ����>
    // �ڷ�ƾ�� �ð� ������ �����Ͽ� �ݺ������� �۾��� ���� Ÿ�̹��� ������ �� ����
    IEnumerator CoRoutineWait()
    {
        yield return new WaitForSeconds(1f);     // n�ʰ� �ð�����
        yield return null;                      // �ð����� ����
    }

}