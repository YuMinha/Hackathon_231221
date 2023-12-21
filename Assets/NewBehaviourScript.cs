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
        // NavMeshAgent 컴포넌트 가져오기
        navi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= waypoints.Count) // waypoints의 크기를 초과하는지 확인
        {
            navi.SetDestination(home.position); // 초과하면 home으로 이동
            
            if(!navi.pathPending && navi.remainingDistance < 0.1f)
            {

                Debug.Log("도착");
                this.enabled = false; // 스크립트 비활성화
                gohome.enabled = true; // GoHome 스크립트 활성화
            }


            //return; // 함수 종료
        }

        else if (index < waypoints.Count)
        {
            Vector3 destination = waypoints[index].transform.position;
            Vector3 direction = (destination - transform.position).normalized; // 웨이포인트를 향하는 방향을 계산
            Quaternion lookRotation = Quaternion.LookRotation(direction); // 해당 방향을 바라보는 회전을 생성

            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed); // 부드럽게 회전

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
                index++;
            }
        }
    }


}


