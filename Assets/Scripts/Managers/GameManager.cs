using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public static Datamanager dataManager;
    public static Datamanager Data { get { return dataManager; } }

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
        GameObject dataObj = new GameObject() { name = "DataManage" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<Datamanager>();
    }
}
