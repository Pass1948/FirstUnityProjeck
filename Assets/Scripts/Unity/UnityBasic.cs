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
        // <게임오브젝트 접근>
        // 컴포넌트가 붙어있는 게임오브젝트는 gameObjeckt 속성을 이용하여 접근가능

        // 컴포넌트가 불어있는 게임오브젝트
        // gameObject.name;                 // 게임오브젝트의 이름 접근
        // gameObject.activeSelf;         // 게임오브젝트의 활성화 여부 접근
        // gameObject.tag;                   // 게임오브젝트의 태그 접근
        // gameObject.layer;               // 게임오브젝트의 레이어 접근

        // <게임오브젝트 참색>
        GameObject.Find("Player");                     // 이름으로 찾기
        GameObject.FindGameObjectWithTag("Player");     // 태그로 하나 찾기
        GameObject.FindGameObjectsWithTag("Player");	// 태그로 모두 찾기 (결과가 배열로 나옴)


        // <게임오브젝트 생성>
        GameObject newObject = new GameObject("newGameObject");     // 게임 오브젝트 만들자 마다 이름주기
                                                                    // 이름을 지정안하면 기본값으로 설정됨

        // <게임오브젝트 삭제>
        if (newObject != null)
            Destroy(newObject, 5f); // 이름뒤에 ,(초)f를 하면 지연삭제가 가능함
    }


    public void ComponentBasic()
    {
        // <게임오브젝트 내 컴포넌트 접근>

        GetComponent<AudioSource>();                        // 컴포넌트에서 GetComponent를 사용할 경우 부착되어 있는 게임오브젝트를 기준으로 접근
        GetComponents<AudioSource>();                       // 컴포넌트를 기준으로 여러 컴포넌트 접근(배열로 나옴)
        gameObject.GetComponent<AudioSource>();             // 게임오브젝트의 컴포넌트 접근
        gameObject.GetComponents<AudioSource>();            // 게임오브젝트의 여러 컴포넌트 접근

        GetComponentInChildren<Rigidbody>();                // 자식 게임오브젝트 포함 컴포넌트 접근
        GetComponentInChildren<Rigidbody>();                // 자식 게임오브젝트 포함 컴포넌트들 접근
        gameObject.GetComponentInChildren<Rigidbody>();     // 게임오브젝트의 자식 게임오브젝트 포함 컴포넌트 접근
        gameObject.GetComponentInChildren<Rigidbody>();     // 게임오브젝트의 자식 게임오브젝트 포함 컴포넌트들 접근

        GetComponentInParent<AudioSource>();                // 부모 게임오브젝트 포함 컴포넌트 접근
        GetComponentsInParent<AudioSource>();               // 부모 게임오브젝트 포함 컴포넌트 접근
        gameObject.GetComponentInParent<AudioSource>();     // 게임오브젝트의 부모 게임오브젝트 포함 컴포넌트 접근
        gameObject.GetComponentsInParent<AudioSource>();    // 게임오브젝트의 부모 게임오브젝트 포함 컴포넌트 접근

        // <컴포넌트 탐색>
        // 프레임마다 탐색을 해서 특별한 경우 이외는 사용권장을 하지않음
        FindObjectOfType<AudioSource>();                    // Scene 내의 컴포넌트 탐색 
        FindObjectsOfType<AudioSource>();                   // Scene 내의 모든 컴포넌트 탐색

        // <컴포넌트 추가>
        // Rigidbody rigid = new Rigidbody();	// 가능하나 의미없음, 컴포넌트는 게임오브젝트에 부착되어 동작함에 의미가 있음
        Rigidbody rigid = gameObject.AddComponent<Rigidbody>();   // 게임오브젝트에 컴포넌트 추가

        // <컴포넌트 삭제>
        Destroy(rigid);

    }
}
