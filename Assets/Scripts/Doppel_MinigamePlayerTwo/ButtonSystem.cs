﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonSystem : MonoBehaviour
{
    // References.
    [SerializeField] private Minigame _minigame;

    // Arrays.
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private Material[] materials;

    // Objects.
    private GameObject randomButton;
    
    // Dictionaries.
    private Dictionary<GameObject, Material> buttonMaterialMap;
    private Dictionary<GameObject, bool> buttonCanComboMap;


    // Action.
    public Action StartFadeOut;

    
    private void Start()
    {
        InitializeButtonMaps();
        _minigame.ActivateBoost += UpdateButtonMaterial;
        _minigame.ActivateBoost += UpdateButtonBoolMap;
    }

    // Fills button dictionaries.
    private void InitializeButtonMaps()
    {
        buttonMaterialMap = new Dictionary<GameObject, Material>();
        buttonCanComboMap = new Dictionary<GameObject, bool>();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttonMaterialMap[buttons[i]] = materials[0];
            buttonCanComboMap[buttons[i]] = false;
        }
        

        // Start animation after 1 sec.
        Invoke("ActivateButtonAnimation", 1f);
    }

    // Updates the button material to current state.
    private void UpdateButtonMaterial()
    {
        for (int i = 0; i < GetButtonLength(); i++)
        {
            var targetMaterial = buttonCanComboMap[buttons[i]] ? materials[1] : materials[0];
            buttons[i].GetComponent<ButtonRenderer>().SetMaterial(targetMaterial);
        }
    }

    private void UpdateButtonBoolMap()
    {
        randomButton = GetRandomActiveButton();
        buttonCanComboMap[randomButton] = true;
        UpdateButtonMaterial();
    }

    public bool GetButtonState(int id)
    {
        return buttonCanComboMap[buttons[id]];
    }

    private void ActivateButtonAnimation()
    {
        var l = GetButtonLength();
        for (int i = 0; i < l; i++)
        {
            if (i < _minigame.GetActiveButtons())
            {
                
            }
            else
            {
                buttons[i].GetComponent<ButtonAnimation>().SetFadingOut(true);
                buttons[i].GetComponent<ButtonAnimation>().PlayAnimation("FadeOut");
            }
        }
    }

    public int GetButtonLength()
    {
        return buttons.Length;
    }
    
    public GameObject GetButton(int x)
    {
        return buttons[x];
    }

    public bool CanButtonCombo(int id)
    {
        return buttonCanComboMap[buttons[id]];
    }

    public void SetButtonCombo(int id, bool x)
    {
        buttonCanComboMap[buttons[id]] = x;
        buttonMaterialMap[buttons[id]] = materials[0];
        UpdateButtonMaterial();
    }

    private GameObject GetRandomActiveButton()
    {
        return buttons[Random.Range(0, _minigame.GetActiveButtons())];
    }
}
