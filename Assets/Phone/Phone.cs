using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject App1;
    public GameObject App2;

    public void OnStart()
    {
        App1.SetActive(true);
        App2.SetActive(false);
        Debug.Log("ssss");
/*
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;*/
    }
}
