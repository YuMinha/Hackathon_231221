using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class App : MonoBehaviour
{
    public GameObject App1;
    public GameObject App2;


    // Update is called once per frame

    public void OnApp()
    {

            App1.SetActive(false);
            App2.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
