using System;
using System.Collections;
using System.Collections.Generic;
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
    public Transform walk;

    public NewBehaviourScript newBehaviourScript;

    public MonoBehaviour gohome;
    public List<GameObject> waypoints;

    private Transform targetTransform;
    private bool isGoTo;
    private bool iscall;
    private bool isParking = false;
    private Vector3 playerForward;
    private Vector3 playerPosition;

    private float parkingDistance = 2f;
    private NavMeshAgent navMeshAgent;

    private Transform initTransform;

    private bool talk = false;

    void Start()
    {
        // NavMeshAgent 컴포넌트 가져오기
        navMeshAgent = GetComponent<NavMeshAgent>();
        initTransform = transform;
        isGoTo = false;
        // 만약 플레이어가 설정되지 않았다면, 예외처리
        if (player == null)
        {
            Debug.LogError("플레이어가 설정되지 않았습니다!");
        }

        playerForward = player.forward;
        playerPosition = player.position + playerForward * 3f;

    }

    void Update()
    {
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

    public void IsCall()
    {
        iscall = true;
        StartCoroutine(Delay(2));
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        iscall = false;
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
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {

            Debug.Log("도착");
            StartCoroutine(DelayM(4));
            
        }
    }
    IEnumerator DelayM(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.enabled = false; // 스크립트 비활성화
        gohome.enabled = true; // GoHome 스크립트 활성화
    }

    

    public void IsGoTo(bool set)
    {
        isGoTo = set;
        if(talk)
        {
            Talk a = GetComponent<Talk>();
            a.Fun();
        }
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
        talk = true;
  
    }

    public void Walking()
    {
        targetTransform = walk;
        talk = true;
    }

    void ParkSmoothly()
    {
        Debug.Log("돌기 시작");
        float disToPosition = Vector3.Distance(transform.position, playerPosition);
        Debug.Log("로봇 위치와 플레이어 위치의 거리: " + disToPosition);

        if (disToPosition < parkingDistance)
        {
            Vector3 targetDirection = playerForward;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
            {
                isParking = false;
                iscall = false;
                Debug.Log("뒤돌기 완");
            }
        }
    }

}