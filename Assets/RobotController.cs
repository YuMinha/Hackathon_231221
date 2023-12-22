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
        // NavMeshAgent ������Ʈ ��������
        navMeshAgent = GetComponent<NavMeshAgent>();
        initTransform = transform;
        isGoTo = false;
        // ���� �÷��̾ �������� �ʾҴٸ�, ����ó��
        if (player == null)
        {
            Debug.LogError("�÷��̾ �������� �ʾҽ��ϴ�!");
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
        // NavMeshAgent�� ����Ͽ� �÷��̾��� ��ġ�� �̵�
        navMeshAgent.SetDestination(playerPosition);
        isParking = true;
    }
    void MoveToTarget()
    {
        // NavMeshAgent�� ����Ͽ� �÷��̾��� ��ġ�� �̵�
        navMeshAgent.SetDestination(targetTransform.position);
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {

            Debug.Log("����");
            StartCoroutine(DelayM(4));
            
        }
    }
    IEnumerator DelayM(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        gohome.enabled = true; // GoHome ��ũ��Ʈ Ȱ��ȭ
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
        Debug.Log("���� ����");
        float disToPosition = Vector3.Distance(transform.position, playerPosition);
        Debug.Log("�κ� ��ġ�� �÷��̾� ��ġ�� �Ÿ�: " + disToPosition);

        if (disToPosition < parkingDistance)
        {
            Vector3 targetDirection = playerForward;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
            {
                isParking = false;
                iscall = false;
                Debug.Log("�ڵ��� ��");
            }
        }
    }

}