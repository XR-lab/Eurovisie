using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject endScreenPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShowEndScreen();
        }
    }

    private void ShowEndScreen()
    {
        GameObject screen = Instantiate(endScreenPrefab, gameObject.transform);
    }
}
