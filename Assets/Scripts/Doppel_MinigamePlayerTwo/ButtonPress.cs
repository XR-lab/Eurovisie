using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private bool isPressed = false;
    private bool isPressedDone = false;

    [SerializeField] private GameObject buttonTop;
    
    private Vector3 pos;
    private Vector3 posPressed;
    private float pressOffset = 0.05f;

    void Start()
    { 
        pos = buttonTop.transform.position;
        posPressed = new Vector3(pos.x, pos.y - pressOffset, pos.z);
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
