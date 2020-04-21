using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject buttonTop;
    
    private Vector3 pos;
    private Vector3 posPressed;
    [SerializeField] private float boxScale = 20f;
    private float pressOffset = 0.05f;

    void Start()
    { 
        pos = buttonTop.transform.position;
        posPressed = new Vector3(pos.x, pos.y - (pressOffset * boxScale), pos.z);
    }


    public void ButtonPressDown()
    {
        buttonTop.transform.position = posPressed;
    }
    
    public void ButtonPressUp()
    {
        buttonTop.transform.position = pos;
    }

}
