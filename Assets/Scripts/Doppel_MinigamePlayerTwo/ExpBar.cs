using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    // References.
    [SerializeField] private Minigame _minigame;
    
    // Components.
    [SerializeField] private Slider slider;
    [SerializeField] private float experience;
    [SerializeField] private float maxExperience;
    [SerializeField] bool isActivated = false;
    private float decayAmount = 5f;
    
    // Actions.
    public Action ExperienceBarFull;

    void Start()
    {
        // Subscribe to event.
        _minigame.SuperActivated += TurnActivationOn;
        
        // Start values.
        experience = 50f;
        maxExperience = 100f;
        UpdateSlider(experience);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddExperience(20);    
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            isActivated = true;
        }

        if (isActivated)
        {
            ActivateExperience();
        }
    }

    private void TurnActivationOn()
    {
        isActivated = true;
    }

    private void ActivateExperience()
    {
        if (experience > 0)
        {
            experience -= decayAmount * Time.deltaTime;
            UpdateSlider(experience);
        }
        else
        {
            experience = 0;
            isActivated = false;
        }
    }

    private void UpdateSlider(float exp)
    {
        slider.value = exp;
    }

    private void AddExperience(int addAmount)
    {
        experience += addAmount;
        experience = Mathf.Clamp(experience, 0, 100);
        UpdateSlider(experience);

        if (experience >= maxExperience)
        {
            ExperienceBarFull.Invoke();
        }
    }
}
