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
            new Dialogue { speaker = "다동이", message = "어디 아프신가요?" },
            new Dialogue { speaker = "유감", message = "요즘 밤을 샜더니 면역력이 떨어진 거 같아" },
            new Dialogue { speaker = "다동이", message = "이런! 그럴 땐 브로콜리나 마늘을 드셔보세요!"},
            new Dialogue { speaker = "유감", message = "면역력을 높이는데 도움이 되는 음식이야?" },
            new Dialogue { speaker = "다동이", message = "네! 도움이 되었으면 좋겠습니다! 얼른 완쾌하시길 바랄게요!" },
            new Dialogue { speaker = "다동이", message = "곧 목적지에 도착합니다." }
        };

        // 대화 시작
        StartDialogue();
    }

    public void Walk()
    {
        isWalk = true;
        walk = new Dialogue[]
        {
            new Dialogue { speaker = "다동이", message = "오늘 날씨는 아주 포근하고 맑네요" },
            new Dialogue { speaker = "다동이", message = "이런 날에는 산책하기 아주 좋답니다 :)"},
            new Dialogue { speaker = "유감", message = "요즘 날씨도 안 좋고 밖에 나와도 같이 걸을 사람이 없어서 산책하기 어려웠어"},
            new Dialogue { speaker = "다동이", message = "저와 같이 걸어요! 저는 언제나 같이 걸을 수 있답니다!"},
            new Dialogue { speaker = "다동이", message = "도움이 필요하시면 언제나 제가 먼저 다가갈게요!" },
        };

        // 대화 시작
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
            //여기는 q눌렀을 때 대화가 넘어감

            currentIndex++;

            // 다음 대화 표시
            yield return new WaitForSeconds(5f);
            StartCoroutine(DisplayNextMessage());
        }
        else
        {
            yield return new WaitForSeconds(5.0f); // 초 동안 대기
            //uiObject.SetActive(false);
            if (isWalk) SceneManager.LoadScene(0);
        }
    }
}
