using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gohome : MonoBehaviour
{
    private NavMeshAgent navi;
    public Transform dadong;

    // Start is called before the first frame update
    void Start()
    {
        navi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navi.SetDestination(dadong.position);
    }
}
