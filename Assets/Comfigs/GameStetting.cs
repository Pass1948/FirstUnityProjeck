using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameStetting
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]  // 이 어트리뷰트를 넣어주면 게임시작시 밑에 스택틱 함수를 실행해줌

    private static void Init()              // 게임시작시 게임매니저가 없으면 새롭게 만들어주는 함수, 초기 설정을 여기에 해두면 게임시작시 초기설정을 활성화해줌
    {


        // 게임을 시작하기 전 필요한 설정들
        
        if (GameManager.Instance == null)
        {
            GameObject gameManager = new GameObject() { name = "GameManager" };
            gameManager.AddComponent<GameManager>();
        }
    }


}
