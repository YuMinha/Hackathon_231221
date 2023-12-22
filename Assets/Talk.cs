using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Talk : MonoBehaviour
{
    public Text talk;
    public Text Name;
    public GameObject uiObject;
    //public bool Clickhospital;
    //public bool Clickwalk;
    private int currentIndex;
    private Dialogue[] hospital;
    private Dialogue[] walk;
    private bool isWalk;


    [System.Serializable]
    public class Dialogue
    {
        public string speaker;
        [TextArea(3, 10)]
        public string message;
        public string[] choices;
    }

    public void Fun()
    {
        uiObject.SetActive(true);
    }
    public void Fun2()
    {
        uiObject.SetActive(false);
    }

    public void Hospital()
    {
        hospital = new Dialogue[]
        {
            new Dialogue { speaker = "�ٵ���", message = "��� �����Ű���?" },
            new Dialogue { speaker = "����", message = "���� ���� ������ �鿪���� ������ �� ����" },
            new Dialogue { speaker = "�ٵ���", message = "�̷�! �׷� �� ����ݸ��� ������ ��ź�����!"},
            new Dialogue { speaker = "����", message = "�鿪���� ���̴µ� ������ �Ǵ� �����̾�?" },
            new Dialogue { speaker = "�ٵ���", message = "��! ������ �Ǿ����� ���ڽ��ϴ�! �� �����Ͻñ� �ٶ��Կ�!" },
            new Dialogue { speaker = "�ٵ���", message = "�� �������� �����մϴ�." }
        };

        // ��ȭ ����
        StartDialogue();
    }

    public void Walk()
    {
        isWalk = true;
        walk = new Dialogue[]
        {
            new Dialogue { speaker = "�ٵ���", message = "���� ������ ���� �����ϰ� ���׿�" },
            new Dialogue { speaker = "�ٵ���", message = "�̷� ������ ��å�ϱ� ���� ����ϴ� :)"},
            new Dialogue { speaker = "����", message = "���� ������ �� ���� �ۿ� ���͵� ���� ���� ����� ��� ��å�ϱ� �������"},
            new Dialogue { speaker = "�ٵ���", message = "���� ���� �ɾ��! ���� ������ ���� ���� �� �ִ�ϴ�!"},
            new Dialogue { speaker = "�ٵ���", message = "������ �ʿ��Ͻø� ������ ���� ���� �ٰ����Կ�!" },
        };

        // ��ȭ ����
        StartDialogue();
    }


    //void Start()
    //{
    //    uiObject.SetActive(true);
    //
    //    if (Clickhospital == true)
    //    {
    //        Hospital();
    //    }
    //    else if (Clickwalk == true)
    //    {
    //        Walk();
    //    }
    //    else
    //    {
    //        uiObject.SetActive(false);
    //    }
    //}

    void StartDialogue()
    {
        currentIndex = 0;
        StartCoroutine(DisplayNextMessage());
    }

    IEnumerator DisplayNextMessage()
    {
        if (currentIndex < (isWalk ? walk.Length : hospital.Length))
        {
            Dialogue currentDialogue = isWalk ? walk[currentIndex] : hospital[currentIndex];

            Name.text = currentDialogue.speaker;
            talk.text = currentDialogue.message;

            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));
            //����� q������ �� ��ȭ�� �Ѿ

            currentIndex++;

            // ���� ��ȭ ǥ��
            yield return new WaitForSeconds(5f);
            StartCoroutine(DisplayNextMessage());
        }
        else
        {
            yield return new WaitForSeconds(5.0f); // �� ���� ���
            //uiObject.SetActive(false);
            if (isWalk) SceneManager.LoadScene(0);
        }
    }
}
