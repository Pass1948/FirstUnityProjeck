using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameStetting
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]  // �� ��Ʈ����Ʈ�� �־��ָ� ���ӽ��۽� �ؿ� ����ƽ �Լ��� ��������

    private static void Init()              // ���ӽ��۽� ���ӸŴ����� ������ ���Ӱ� ������ִ� �Լ�, �ʱ� ������ ���⿡ �صθ� ���ӽ��۽� �ʱ⼳���� Ȱ��ȭ����
    {


        // ������ �����ϱ� �� �ʿ��� ������
        
        if (GameManager.Instance == null)
        {
            GameObject gameManager = new GameObject() { name = "GameManager" };
            gameManager.AddComponent<GameManager>();
        }
    }


}
