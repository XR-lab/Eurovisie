using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    public GameObject pS;
    public GameObject pS1;
    public GameObject pS2;
    public GameObject pS3;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pS.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            pS.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            pS1.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            pS1.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            pS2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            pS2.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            pS3.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            pS3.SetActive(false);
        }
    }

}
