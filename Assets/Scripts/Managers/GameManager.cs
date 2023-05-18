using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; }}

    public static DataManager dataManager;
    public static DataManager Data { get { return dataManager; } }

    private void Awake()                        // ���� ���ӸŴ����� ���� ���� ���� �� ó�� ���ص� �ϳ��� ���Ե� (����Ƽ������Ʈ �߰� �Ǵ� new�� ���� �߰��� ����)
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);                // �ش� ������Ʈ�� Scene�� ��ȯ�Ǿ ������ �����ʰ� ������
        instance = this;
        InitManagers();
    }

    private void OnDestroy()
    {
        if(instance == this)
            instance = null;
    }

    private void InitManagers()
    {
        // DataManager init
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager>();
    }
}
