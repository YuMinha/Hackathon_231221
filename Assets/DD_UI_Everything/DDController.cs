using UnityEngine;

public class DDController : MonoBehaviour
{
    public GameObject DD_UI; // DD_UI 오브젝트를 연결합니다.
    public GameObject Text_F; // Text_F 오브젝트를 연결합니다.
    public float detectDistance = 3.0f; // DD 오브젝트와 플레이어 간의 거리를 설정합니다.

    private Transform player; // 플레이어의 Transform을 저장합니다.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어의 Transform을 가져옵니다. 플레이어 오브젝트에 "Player" 태그가 있어야 합니다.
        DD_UI.SetActive(false); // 시작 시 DD_UI를 비활성화합니다.
        Text_F.SetActive(false); // 시작 시 Text_F를 비활성화합니다.
    }

    void Update()
    {
        DetectPlayer();
        ActivateUI();
    }

    void DetectPlayer()
    {
        float distance = Vector3.Distance(player.position, transform.position); // 플레이어와 DD 오브젝트 사이의 거리를 계산합니다.

        if (distance <= detectDistance && !DD_UI.activeSelf) // 플레이어가 DD 오브젝트와 가까이 있고, DD_UI가 비활성화된 경우
        {
            Text_F.SetActive(true); // Text_F를 활성화합니다.
        }
        else
        {
            Text_F.SetActive(false); // 그렇지 않을 경우 Text_F를 비활성화합니다.
            if (distance > detectDistance && DD_UI.activeSelf) // 플레이어가 DD 오브젝트에서 멀어지고, DD_UI가 활성화된 경우
            {
                DD_UI.SetActive(false); // DD_UI를 비활성화합니다.
            }
        }
    }

    void ActivateUI()
    {
        if (Text_F.activeSelf && Input.GetKeyDown(KeyCode.F)) // Text_F가 활성화되어 있고, F키를 누른 경우
        {
            DD_UI.SetActive(!DD_UI.activeSelf); // DD_UI의 활성화 상태를 전환합니다.
            Text_F.SetActive(!DD_UI.activeSelf); // DD_UI의 상태와 반대로 Text_F를 설정합니다.
        }
    }
}
