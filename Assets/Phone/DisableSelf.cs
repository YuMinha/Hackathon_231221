using UnityEngine;
using UnityEngine.UI;

public class DisableSelf : MonoBehaviour
{
    public Button buttonC; // C 버튼을 연결합니다.

    void Start()
    {
        buttonC.onClick.AddListener(DisableA);
    }

    void DisableA()
    {
        gameObject.SetActive(false); // A를 비활성화합니다.
    }
}