using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ButtonSystem : MonoBehaviour
{
    // References.
    [SerializeField] private Minigame _minigame;
    
    // Arrays.
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private Color[] colors;
    
    // Objects.
    [SerializeField] private GameObject particleEffect;
    
    // Dictionaries.
    private Dictionary<GameObject, Color> buttonColorMap;
    private Dictionary<GameObject, bool> buttonCanComboMap;

    
    // Action.
    public Action StartFadeOut;
    

    private void Start()
    {
        InitializeButtonMaps();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartBoostAnimation(2);
        }
    }

    // Fills the button color dictionary.
    private void InitializeButtonMaps()
    {
        buttonColorMap = new Dictionary<GameObject, Color>();
        buttonCanComboMap = new Dictionary<GameObject, bool>();
        
        for (int i = 0; i < GetButtonLength(); i++)
        {
            if (i < _minigame.GetActiveButtons())
            {
                buttonColorMap[buttons[i]] = colors[1];
            }
            else
            {
                buttonColorMap[buttons[i]] = colors[0];
            }

            // Sets all buttons' can combo on false;
            buttonCanComboMap[buttons[i]] = false;
        }
        // UpdateButtonColors();
        Invoke("ActivateButtonAnimation", 1f);
    }

    private void UpdateButtonColors()
    {
        for (int i = 0; i < GetButtonLength(); i++)
        {
            buttons[i].GetComponent<ButtonRenderer>().SetColor(buttonColorMap[buttons[i]]);
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

    private void StartBoostAnimation(int id)
    {
        buttonCanComboMap[buttons[id]] = true;
        buttons[id].GetComponent<ButtonAnimation>().PlayAnimation("Combo");
        Instantiate(particleEffect, buttons[id].transform);
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
}
