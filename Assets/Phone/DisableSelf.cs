using UnityEngine;
using UnityEngine.UI;

public class DisableSelf : MonoBehaviour
{
    public Button buttonC; // C ��ư�� �����մϴ�.

    void Start()
    {
        buttonC.onClick.AddListener(DisableA);
    }

    void DisableA()
    {
        gameObject.SetActive(false); // A�� ��Ȱ��ȭ�մϴ�.
    }
}