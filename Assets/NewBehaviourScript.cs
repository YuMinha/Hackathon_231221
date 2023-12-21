using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    public Transform home;
    public Transform dadong;
    public MonoBehaviour gohome;

    private NavMeshAgent navi;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        // NavMeshAgent ������Ʈ ��������
        navi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= waypoints.Count) // waypoints�� ũ�⸦ �ʰ��ϴ��� Ȯ��
        {
            navi.SetDestination(home.position); // �ʰ��ϸ� home���� �̵�
            
            if(!navi.pathPending && navi.remainingDistance < 0.1f)
            {

                Debug.Log("����");
                this.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
                gohome.enabled = true; // GoHome ��ũ��Ʈ Ȱ��ȭ
            }


            //return; // �Լ� ����
        }

        else if (index < waypoints.Count)
        {
            Vector3 destination = waypoints[index].transform.position;
            Vector3 direction = (destination - transform.position).normalized; // ��������Ʈ�� ���ϴ� ������ ���
            Quaternion lookRotation = Quaternion.LookRotation(direction); // �ش� ������ �ٶ󺸴� ȸ���� ����

            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed); // �ε巴�� ȸ��

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
                index++;
            }
        }
    }


}


