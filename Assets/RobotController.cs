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
        // NavMeshAgent 컴포넌트 가져오기
        navMeshAgent = GetComponent<NavMeshAgent>();

        isGoTo = false;
        // 만약 플레이어가 설정되지 않았다면, 예외처리
        if (player == null)
        {
            Debug.LogError("플레이어가 설정되지 않았습니다!");
        }
    }

    void Update()
    {
        // E 키를 눌렀을 때 로봇이 플레이어를 향해
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
        // NavMeshAgent를 사용하여 플레이어의 위치로 이동
        navMeshAgent.SetDestination(playerPosition);
        isParking = true;
    }
    void MoveToTarget()
    {
        // NavMeshAgent를 사용하여 플레이어의 위치로 이동
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
        Debug.Log("돌기 시작");
        float disToPosition = Vector3.Distance(transform.position, playerPosition);

        if (disToPosition < parkingDistance)
        {
            Vector3 targetDirection = playerForward;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

            if (disToPosition < 0.1f)
            {
                isParking = false;
                Debug.Log("뒤돌기 완");
            }
        }
    }
}