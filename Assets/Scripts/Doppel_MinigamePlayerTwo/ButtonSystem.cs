using System;
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
    [SerializeField] private GameObject particleEffect;
    private GameObject randomButton;
    
    // Dictionaries.
    private Dictionary<GameObject, Material> buttonMaterialMap;
    private Dictionary<GameObject, bool> buttonCanComboMap;

    
    // Action.
    public Action StartFadeOut;
    public Action ActivateBoost;
    

    private void Start()
    {
        InitializeButtonMaps();
        ActivateBoost += UpdateButtonMaterial;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ActivateBoost.Invoke();
        }
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

        // Set random button able to combo.
        // randomButton = GetRandomActiveButton();
        randomButton = buttons[0];
        buttonCanComboMap[randomButton] = true;
        
        // Start animation after 1 sec.
        Invoke("ActivateButtonAnimation", 1f);
    }

    // Updates the button material to current state.
    private void UpdateButtonMaterial()
    {
        for (int i = 0; i < GetButtonLength(); i++)
        {
            if (buttonCanComboMap[buttons[i]])
            {
                buttons[i].GetComponent<ButtonRenderer>().SetMaterial(materials[1]);
            }
            else
            {
                buttons[i].GetComponent<ButtonRenderer>().SetMaterial(materials[0]);
            }
            
            // Enables additional material.
            buttons[i].GetComponent<ToggleAdditionalMaterial>().ToggleGameObject(buttonCanComboMap[buttons[i]]);
        }
    }

    private void ActivateButtonAnimation()
    {
        for (int i = 0; i < GetButtonLength(); i++)
        {
            if (i < _minigame.GetActiveButtons())
            {
                buttons[i].GetComponent<ButtonAnimation>().PlayAnimation("Activate");
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

    private GameObject GetRandomActiveButton()
    {
        return buttons[Random.Range(0, _minigame.GetActiveButtons())];
    }
}
