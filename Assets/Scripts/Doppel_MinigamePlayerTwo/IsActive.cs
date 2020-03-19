using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class IsActive : MonoBehaviour
{
    private bool isButtonActive = false;
    
    // Public function to set button active or not.
    public void EnableButton()
    {
        isButtonActive = true;
    }
    
    public void DisableButton()
    {
        isButtonActive = false;
    }
    
    // Returns if the button is active or not.
    public bool IsButtonActive()
    {
        return isButtonActive;
    }
}
