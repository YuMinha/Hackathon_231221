using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DD_UI : MonoBehaviour
{
    public Button[] buttons; // ���⿡ btn1, btn2, btn3, btn4, btn5�� �����մϴ�.
    public Button Check_NO; // Check_NO ��ư�� �����մϴ�.
    public Button Check_Check; // Check_Check ��ư�� �����մϴ�.
    public Image DD_Talk_Background; // DD_Talk_Background �̹����� �����մϴ�.
    public Sprite[] buttonImages; // �� ��ư�� ���� �� �ٲ� �̹������� �ֽ��ϴ�.
    public Text childText; // UI1_Background�� �ڽ� ������Ʈ �ؽ�Ʈ�� �����մϴ�.
    public string[] buttonTexts; // �� ��ư�� ���� �� �ٲ� �ؽ�Ʈ���� �ֽ��ϴ�.

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Ŭ���� ������ �ذ��ϱ� ���� ���ο� ������ �����մϴ�.
            buttons[i].onClick.AddListener(() => ChangeImageAndText(index));
        }

        // Check_NO ��ư�� Check_Check ��ư�� Ŭ���Ǹ� UI�� �ݽ��ϴ�.
        Check_NO.onClick.AddListener(CloseUI);
        Check_Check.onClick.AddListener(CloseUI);
    }

    void Update()
    {
        // DD_UI�� Ȱ��ȭ�Ǿ� �ִٸ� ���콺 Ŀ���� ȭ�鿡 ǥ���ϰ�, �þ� �������� ���߰� �մϴ�.
        if (gameObject.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None; // ���콺 Ŀ�� ����� �����մϴ�.
            Cursor.visible = true; // ���콺 Ŀ���� ���̰� �մϴ�.
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ���� ��޴ϴ�.
            Cursor.visible = false; // ���콺 Ŀ���� ����ϴ�.
        }
    }

    void ChangeImageAndText(int index)
    {
        DD_Talk_Background.sprite = buttonImages[index];
        childText.text = buttonTexts[index];
    }

    void CloseUI()
    {
        gameObject.SetActive(false); // DD_UI�� ��Ȱ��ȭ�մϴ�.
    }
}
