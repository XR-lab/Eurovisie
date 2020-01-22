using System.Collections;
using System.Collections.Generic;
using Eurovision.Input;
using UnityEditor;
using UnityEngine;

public class EditorInputSelection
{
    private const string _hardwareInputMenu = "Eurovision/Input/HardwareInput";
    private const string _keyboardInputMenu = "Eurovision/Input/KeyboardInput";
    
    [MenuItem(_hardwareInputMenu)]
    public static void HardwareInput()
    {
        Menu.SetChecked(_hardwareInputMenu, true);
        Menu.SetChecked(_keyboardInputMenu, false);
        
        Object.FindObjectOfType<Eurovision.Input.InputMode>().SetInputMode(InputMode.InputModeType.Hardware);
    }

    [MenuItem(_keyboardInputMenu)]
    public static void KeyboardInput()
    {
        Menu.SetChecked(_hardwareInputMenu, false);
        Menu.SetChecked(_keyboardInputMenu, true);
        
        Object.FindObjectOfType<Eurovision.Input.InputMode>().SetInputMode(InputMode.InputModeType.Keyboard);
    }
}
