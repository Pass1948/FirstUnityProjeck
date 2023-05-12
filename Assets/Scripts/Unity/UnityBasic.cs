using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    public AudioSource audioSource;
    private GameObject player;
    private void Start()
    {
        GameObjecktBasic();
        ComponentBasic();
    }

    public void GameObjecktBasic()
    {
        // <���ӿ�����Ʈ ����>
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� gameObjeckt �Ӽ��� �̿��Ͽ� ���ٰ���

        // ������Ʈ�� �Ҿ��ִ� ���ӿ�����Ʈ
        // gameObject.name;                 // ���ӿ�����Ʈ�� �̸� ����
        // gameObject.activeSelf;         // ���ӿ�����Ʈ�� Ȱ��ȭ ���� ����
        // gameObject.tag;                   // ���ӿ�����Ʈ�� �±� ����
        // gameObject.layer;               // ���ӿ�����Ʈ�� ���̾� ����

        // <���ӿ�����Ʈ ����>
        GameObject.Find("Player");                     // �̸����� ã��
        GameObject.FindGameObjectWithTag("Player");     // �±׷� �ϳ� ã��
        GameObject.FindGameObjectsWithTag("Player");	// �±׷� ��� ã�� (����� �迭�� ����)


        // <���ӿ�����Ʈ ����>
        GameObject newObject = new GameObject("newGameObject");     // ���� ������Ʈ ������ ���� �̸��ֱ�
                                                                    // �̸��� �������ϸ� �⺻������ ������

        // <���ӿ�����Ʈ ����>
        if (newObject != null)
            Destroy(newObject, 5f); // �̸��ڿ� ,(��)f�� �ϸ� ���������� ������
    }


    public void ComponentBasic()
    {
        // <���ӿ�����Ʈ �� ������Ʈ ����>

        GetComponent<AudioSource>();                        // ������Ʈ���� GetComponent�� ����� ��� �����Ǿ� �ִ� ���ӿ�����Ʈ�� �������� ����
        GetComponents<AudioSource>();                       // ������Ʈ�� �������� ���� ������Ʈ ����(�迭�� ����)
        gameObject.GetComponent<AudioSource>();             // ���ӿ�����Ʈ�� ������Ʈ ����
        gameObject.GetComponents<AudioSource>();            // ���ӿ�����Ʈ�� ���� ������Ʈ ����

        GetComponentInChildren<Rigidbody>();                // �ڽ� ���ӿ�����Ʈ ���� ������Ʈ ����
        GetComponentInChildren<Rigidbody>();                // �ڽ� ���ӿ�����Ʈ ���� ������Ʈ�� ����
        gameObject.GetComponentInChildren<Rigidbody>();     // ���ӿ�����Ʈ�� �ڽ� ���ӿ�����Ʈ ���� ������Ʈ ����
        gameObject.GetComponentInChildren<Rigidbody>();     // ���ӿ�����Ʈ�� �ڽ� ���ӿ�����Ʈ ���� ������Ʈ�� ����

        GetComponentInParent<AudioSource>();                // �θ� ���ӿ�����Ʈ ���� ������Ʈ ����
        GetComponentsInParent<AudioSource>();               // �θ� ���ӿ�����Ʈ ���� ������Ʈ ����
        gameObject.GetComponentInParent<AudioSource>();     // ���ӿ�����Ʈ�� �θ� ���ӿ�����Ʈ ���� ������Ʈ ����
        gameObject.GetComponentsInParent<AudioSource>();    // ���ӿ�����Ʈ�� �θ� ���ӿ�����Ʈ ���� ������Ʈ ����

        // <������Ʈ Ž��>
        // �����Ӹ��� Ž���� �ؼ� Ư���� ��� �ܴ̿� �������� ��������
        FindObjectOfType<AudioSource>();                    // Scene ���� ������Ʈ Ž�� 
        FindObjectsOfType<AudioSource>();                   // Scene ���� ��� ������Ʈ Ž��

        // <������Ʈ �߰�>
        // Rigidbody rigid = new Rigidbody();	// �����ϳ� �ǹ̾���, ������Ʈ�� ���ӿ�����Ʈ�� �����Ǿ� �����Կ� �ǹ̰� ����
        Rigidbody rigid = gameObject.AddComponent<Rigidbody>();   // ���ӿ�����Ʈ�� ������Ʈ �߰�

        // <������Ʈ ����>
        Destroy(rigid);

    }
}
