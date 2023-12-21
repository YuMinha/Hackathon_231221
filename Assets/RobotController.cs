using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    public Transform player;
    public Transform supermarket;
    public Transform hospital;
    public Transform stadium;
    public Transform home;
    public Transform busstop;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // NavMeshAgent ������Ʈ ��������
        navMeshAgent = GetComponent<NavMeshAgent>();

        // ���� �÷��̾ �������� �ʾҴٸ�, ����ó��
        if (player == null)
        {
            Debug.LogError("�÷��̾ �������� �ʾҽ��ϴ�!");
        }
    }

    void Update()
    {
        // E Ű�� ������ �� �κ��� �÷��̾ ���� �̵�
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        // NavMeshAgent�� ����Ͽ� �÷��̾��� ��ġ�� �̵�
        navMeshAgent.SetDestination(hospital.position);
    }
}
