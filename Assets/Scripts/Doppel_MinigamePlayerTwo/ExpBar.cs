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
    [SerializeField] private float currentExperience;
    [SerializeField] private float maxExperience;
    [SerializeField] private float targetExperience;
    [SerializeField] private float lerpSpeed = 1f;
    [SerializeField] private bool isUpdatingValue;
    [SerializeField] private bool isActivated;
    private float decayAmount = 5f;
    
    // Actions.
    public Action ExperienceBarFull;

    void Start()
    {
        // Subscribe to event.

        // Start values.
        currentExperience = 20f;
        maxExperience = 100f;
        targetExperience = 0f;
        UpdateSlider();
        isUpdatingValue = true;
        isActivated = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddExperience(20);
            print("Added experience");
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            isActivated = true;
        }

        if (isActivated)
        {
            ActivateExperience();
        }

        if (isUpdatingValue && currentExperience < targetExperience)
        {
            UpdateSlider();
        }
    }

    private void TurnActivationOn()
    {
        isActivated = true;
    }

    private void ActivateExperience()
    {
        if (currentExperience > 0)
        {
            currentExperience -= decayAmount * Time.deltaTime;
            UpdateSlider();
        }
        else
        {
            currentExperience = 0;
            isActivated = false;
        }
    }

    private void UpdateSlider()
    {
        currentExperience = Mathf.Lerp(currentExperience, targetExperience, lerpSpeed * Time.deltaTime);
        slider.value = Mathf.Lerp(slider.value, currentExperience, lerpSpeed * Time.deltaTime);

        if (currentExperience >= targetExperience)
        {
            isUpdatingValue = false;
        }
    }

    private void AddExperience(int addAmount)
    {
        targetExperience += addAmount;
        isUpdatingValue = true;
    }
}
