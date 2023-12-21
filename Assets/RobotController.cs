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
        // NavMeshAgent 컴포넌트 가져오기
        navMeshAgent = GetComponent<NavMeshAgent>();

        // 만약 플레이어가 설정되지 않았다면, 예외처리
        if (player == null)
        {
            Debug.LogError("플레이어가 설정되지 않았습니다!");
        }
    }

    void Update()
    {
        // E 키를 눌렀을 때 로봇이 플레이어를 향해 이동
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        // NavMeshAgent를 사용하여 플레이어의 위치로 이동
        navMeshAgent.SetDestination(hospital.position);
    }
}
