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
    public Action ActivateBoost;
    
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

            if (buttonSystem.GetButtonState(0))
            {
                buttonSystem.GetButton(0).GetComponent<ButtonPress>().ActivateSuper();
                buttonSystem.GetButton(0).GetComponent<ButtonParticle>().InstantiateParticleRainbow();
                buttonSystem.SetButtonCombo(0,  false);
            }
            else
            {
               buttonSystem.GetButton(0).GetComponent<ButtonParticle>().InstantiateParticleNormal(); 
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            buttonSystem.GetButton(0).GetComponent<ButtonPress>().ButtonPressUp();
        }
        
        // Button 1.
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttonSystem.GetButton(1).GetComponent<ButtonPress>().ButtonPressDown();
            
            if (buttonSystem.GetButtonState(1))
            {
                buttonSystem.GetButton(1).GetComponent<ButtonPress>().ActivateSuper();
                buttonSystem.GetButton(1).GetComponent<ButtonParticle>().InstantiateParticleRainbow();
                buttonSystem.SetButtonCombo(1,  false);
            }
            else
            {
                buttonSystem.GetButton(1).GetComponent<ButtonParticle>().InstantiateParticleNormal(); 
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            buttonSystem.GetButton(1).GetComponent<ButtonPress>().ButtonPressUp();
        }
        
        // Button 2.
        if (Input.GetKeyDown(KeyCode.D))
        {
            buttonSystem.GetButton(2).GetComponent<ButtonPress>().ButtonPressDown();
            
            if (buttonSystem.GetButtonState(2))
            {
                buttonSystem.GetButton(2).GetComponent<ButtonPress>().ActivateSuper();
                buttonSystem.GetButton(2).GetComponent<ButtonParticle>().InstantiateParticleRainbow();
                buttonSystem.SetButtonCombo(2,  false);
            }
            else
            {
                buttonSystem.GetButton(2).GetComponent<ButtonParticle>().InstantiateParticleNormal(); 
            }
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            buttonSystem.GetButton(2).GetComponent<ButtonPress>().ButtonPressUp();
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            ActivateBoost.Invoke();
        }
    }

    public int GetActiveButtons()
    {
        return activeButtons;
    }
}
