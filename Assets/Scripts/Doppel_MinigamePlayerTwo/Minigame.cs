using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    [SerializeField] private ButtonSystem buttonSystem;
    [SerializeField] private int activeButtons = 3;

    public Action GameStarted;
    public Action SuperActivated;
    
    // Game.
    private bool isPlaying = false;

    void Start()
    {
        isPlaying = true;
    }

    
    void Update()
    {
        if (isPlaying)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        // Button 0.
        if (Input.GetKeyDown(KeyCode.A))
        {
            buttonSystem.GetButton(0).GetComponent<ButtonPress>().ButtonPressDown();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            buttonSystem.GetButton(0).GetComponent<ButtonPress>().ButtonPressUp();
        }
        
        // Button 1.
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttonSystem.GetButton(1).GetComponent<ButtonPress>().ButtonPressDown();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            buttonSystem.GetButton(1).GetComponent<ButtonPress>().ButtonPressUp();
        }
        
        // Button 2.
        if (Input.GetKeyDown(KeyCode.D))
        {
            buttonSystem.GetButton(2).GetComponent<ButtonPress>().ButtonPressDown();
            if (buttonSystem.CanButtonCombo(2))
            {
                buttonSystem.GetButton(2).GetComponent<ButtonAnimation>().PlayAnimation("Idle");
                SuperActivated.Invoke();
            }
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            buttonSystem.GetButton(2).GetComponent<ButtonPress>().ButtonPressUp();
        }
    }

    public int GetActiveButtons()
    {
        return activeButtons;
    }
}
