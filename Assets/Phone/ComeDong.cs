using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ComeDong : MonoBehaviour
{
    public GameObject App1;
    public GameObject App2;
    public GameObject phone;


    public void OnEnd()
    {
        {
            App1.SetActive(false);
            App2.SetActive(false);
            phone.SetActive(true);
        }
    }

}
