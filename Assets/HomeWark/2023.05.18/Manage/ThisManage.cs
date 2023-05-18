using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisManage : MonoBehaviour
{
    private static ThisManage instance;
    public static ThisManage Instance { get { return instance; } }

    public static ThisDataManage dataManager;
    public static ThisDataManage Data { get { return dataManager; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
        instance = this;
        InitManagers();
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    private void InitManagers()
    {
        GameObject dataObj = new GameObject() { name = "ThisDataManage" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<ThisDataManage>();
    }
}

