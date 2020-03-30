using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    [SerializeField] private ButtonSystem buttonSystem;
    [SerializeField] private int activeButtons = 3;
    private int maxButtons = 12;

    public Action GameStarted;
    public Action ActivateBoost;
    
    // Game.
    private bool isPlaying = false;
    
    // Button activations.
    private bool isIncreasingButtons = false;
    private float activeButtonCounter = 0f;
    private float buttonDelay = 0.2f;
    [SerializeField] private int buttonIncrease = 3;
    private int currentActiveButtons = 0;
    

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
            HandleKeyInput(0);
        } else if (Input.GetKeyUp(KeyCode.A))
        {
            HandleKeyUp(0);
        }

        // Button 1.
        if (Input.GetKeyDown(KeyCode.S))
        {
            HandleKeyInput(1);
        } else if (Input.GetKeyUp(KeyCode.S))
        {
            HandleKeyUp(1);
        }
        
        // Button 2.
        if (Input.GetKeyDown(KeyCode.D))
        {
           HandleKeyInput(2);
        } else if (Input.GetKeyUp(KeyCode.D))
        {
            HandleKeyUp(2);
        }
        
        // Activate boost.
        if (Input.GetKeyDown(KeyCode.B))
        {
            ActivateBoost.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.F) && activeButtons < maxButtons)
        {
            currentActiveButtons = activeButtons;
            activeButtons += buttonIncrease;
            activeButtonCounter = 0.95f;
            isIncreasingButtons = true;
        }

        if (isIncreasingButtons)
        {
            if (activeButtons > currentActiveButtons)
            {
                activeButtonCounter += Time.deltaTime;
                if (activeButtonCounter >= buttonDelay)
                {
                    IncreaseActiveButtons(currentActiveButtons);
                    activeButtonCounter = 0f;
                }
            }
        }
    }

    private void IncreaseActiveButtons(int id)
    {
        currentActiveButtons++;
        buttonSystem.GetButton(id).GetComponent<ButtonAnimation>().SetFadingIn(true);
        buttonSystem.GetButton(id).GetComponent<ButtonAnimation>().PlayAnimation("FadeIn");
        
        if (currentActiveButtons == activeButtons)
        {
            isIncreasingButtons = false;
        }
    }

    public int GetActiveButtons()
    {
        return activeButtons;
    }

    private void HandleKeyInput(int id)
    {
        buttonSystem.GetButton(id).GetComponent<ButtonPress>().ButtonPressDown();

        if (buttonSystem.GetButtonState(id))
        {
            buttonSystem.GetButton(id).GetComponent<ButtonPress>().ActivateSuper();
            buttonSystem.GetButton(id).GetComponent<ButtonParticle>().InstantiateParticleRainbow();
            buttonSystem.SetButtonCombo(0,  false);
        }
        else
        {
            buttonSystem.GetButton(id).GetComponent<ButtonParticle>().InstantiateParticleNormal(); 
        }
    }

    private void HandleKeyUp(int id)
    {
        buttonSystem.GetButton(id).GetComponent<ButtonPress>().ButtonPressUp();
        buttonSystem.SetButtonCombo(id, false);
    }
}
