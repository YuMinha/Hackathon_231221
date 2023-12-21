using UnityEngine;

public class DDController : MonoBehaviour
{
    public GameObject DD_UI; // DD_UI ������Ʈ�� �����մϴ�.
    public GameObject Text_F; // Text_F ������Ʈ�� �����մϴ�.
    public float detectDistance = 3.0f; // DD ������Ʈ�� �÷��̾� ���� �Ÿ��� �����մϴ�.

    private Transform player; // �÷��̾��� Transform�� �����մϴ�.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾��� Transform�� �����ɴϴ�. �÷��̾� ������Ʈ�� "Player" �±װ� �־�� �մϴ�.
        DD_UI.SetActive(false); // ���� �� DD_UI�� ��Ȱ��ȭ�մϴ�.
        Text_F.SetActive(false); // ���� �� Text_F�� ��Ȱ��ȭ�մϴ�.
    }

    void Update()
    {
        DetectPlayer();
        ActivateUI();
    }

    void DetectPlayer()
    {
        float distance = Vector3.Distance(player.position, transform.position); // �÷��̾�� DD ������Ʈ ������ �Ÿ��� ����մϴ�.

        if (distance <= detectDistance && !DD_UI.activeSelf) // �÷��̾ DD ������Ʈ�� ������ �ְ�, DD_UI�� ��Ȱ��ȭ�� ���
        {
            Text_F.SetActive(true); // Text_F�� Ȱ��ȭ�մϴ�.
        }
        else
        {
            Text_F.SetActive(false); // �׷��� ���� ��� Text_F�� ��Ȱ��ȭ�մϴ�.
            if (distance > detectDistance && DD_UI.activeSelf) // �÷��̾ DD ������Ʈ���� �־�����, DD_UI�� Ȱ��ȭ�� ���
            {
                DD_UI.SetActive(false); // DD_UI�� ��Ȱ��ȭ�մϴ�.
            }
        }
    }

    void ActivateUI()
    {
        if (Text_F.activeSelf && Input.GetKeyDown(KeyCode.F)) // Text_F�� Ȱ��ȭ�Ǿ� �ְ�, FŰ�� ���� ���
        {
            DD_UI.SetActive(!DD_UI.activeSelf); // DD_UI�� Ȱ��ȭ ���¸� ��ȯ�մϴ�.
            Text_F.SetActive(!DD_UI.activeSelf); // DD_UI�� ���¿� �ݴ�� Text_F�� �����մϴ�.
        }
    }
}
