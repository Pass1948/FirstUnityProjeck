using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; }}

    public static DataManager dataManager;
    public static DataManager Data { get { return dataManager; } }

    private void Awake()                        // 여러 게임매니저를 만들어도 게임 시작 시 처음 정해둔 하나만 남게됨 (유니티컴포넌트 추가 또는 new를 통한 추가를 막음)
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);                // 해당 컴포넌트는 Scene이 전환되어도 삭제가 되지않게 설정함
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
