using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DD_UI : MonoBehaviour
{
    public Button[] buttons; // 여기에 btn1, btn2, btn3, btn4, btn5를 연결합니다.
    public Button Check_NO; // Check_NO 버튼을 연결합니다.
    public Button Check_Check; // Check_Check 버튼을 연결합니다.
    public Image DD_Talk_Background; // DD_Talk_Background 이미지를 연결합니다.
    public Sprite[] buttonImages; // 각 버튼이 눌릴 때 바뀔 이미지들을 넣습니다.
    public Text childText; // UI1_Background의 자식 오브젝트 텍스트를 연결합니다.
    public string[] buttonTexts; // 각 버튼이 눌릴 때 바뀔 텍스트들을 넣습니다.

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // 클로저 문제를 해결하기 위해 새로운 변수를 생성합니다.
            buttons[i].onClick.AddListener(() => ChangeImageAndText(index));
        }

        // Check_NO 버튼과 Check_Check 버튼이 클릭되면 UI를 닫습니다.
        Check_NO.onClick.AddListener(CloseUI);
        Check_Check.onClick.AddListener(CloseUI);
    }

    void Update()
    {
        // DD_UI가 활성화되어 있다면 마우스 커서를 화면에 표시하고, 시야 움직임을 멈추게 합니다.
        if (gameObject.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None; // 마우스 커서 잠금을 해제합니다.
            Cursor.visible = true; // 마우스 커서를 보이게 합니다.
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // 마우스 커서를 잠급니다.
            Cursor.visible = false; // 마우스 커서를 숨깁니다.
        }
    }

    void ChangeImageAndText(int index)
    {
        DD_Talk_Background.sprite = buttonImages[index];
        childText.text = buttonTexts[index];
    }

    void CloseUI()
    {
        gameObject.SetActive(false); // DD_UI를 비활성화합니다.
    }
}
