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

    private Transform targetTransform;
    private bool isGoTo;
    private bool iscall;
    private bool isParking = false;
    private Vector3 playerForward;
    private Vector3 playerPosition;

    private float parkingDistance = 2f;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // NavMeshAgent ������Ʈ ��������
        navMeshAgent = GetComponent<NavMeshAgent>();

        isGoTo = false;
        // ���� �÷��̾ �������� �ʾҴٸ�, ����ó��
        if (player == null)
        {
            Debug.LogError("�÷��̾ �������� �ʾҽ��ϴ�!");
        }
    }

    void Update()
    {
        // E Ű�� ������ �� �κ��� �÷��̾ ����
        if (Input.GetKeyDown(KeyCode.E) && !isParking)
        {
            playerForward = player.forward;
            playerPosition = player.position + playerForward * 3f;
            iscall = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            iscall = false;
        }
        if (iscall)
        {
            MoveToPlayer();
        }
        else if (isGoTo)
        {
            MoveToTarget();
        }

        if (isParking)
        {
            ParkSmoothly();
        }
    }

    void MoveToPlayer()
    {
        // NavMeshAgent�� ����Ͽ� �÷��̾��� ��ġ�� �̵�
        navMeshAgent.SetDestination(playerPosition);
        isParking = true;
    }
    void MoveToTarget()
    {
        // NavMeshAgent�� ����Ͽ� �÷��̾��� ��ġ�� �̵�
        navMeshAgent.SetDestination(targetTransform.position);
    }

    public void IsGoTo(bool set)
    {
        isGoTo = set;
    }

    public void isCall()
    {
        iscall = true;
    }

    public void MoveToSupermarket()
    {
        targetTransform = supermarket;
    }
    public void MoveToHome()
    {
        targetTransform = home;
    }
    public void MoveToBusstop()
    {
        targetTransform = busstop;
    }
    public void MoveToStadium()
    {
        targetTransform = stadium;
    }
    public void MoveToHospital()
    {
        targetTransform = hospital;
    }

    void ParkSmoothly()
    {
        Debug.Log("���� ����");
        float disToPosition = Vector3.Distance(transform.position, playerPosition);

        if (disToPosition < parkingDistance)
        {
            Vector3 targetDirection = playerForward;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

            if (disToPosition < 0.1f)
            {
                isParking = false;
                Debug.Log("�ڵ��� ��");
            }
        }
    }
}