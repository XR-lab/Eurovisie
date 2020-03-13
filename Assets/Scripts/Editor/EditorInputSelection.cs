using Eurovision.Input;
using UnityEditor;
using UnityEngine;

// ToDo: Use initialize on load attribute to make sure our settings match 
// https://docs.unity3d.com/Manual/RunningEditorCodeOnLaunch.html
public class EditorInputSelection
{
    private const string HardwareInputMenu = "Eurovision/Input/HardwareInput";
    private const string KeyboardInputMenu = "Eurovision/Input/KeyboardInput";
    
    [MenuItem(HardwareInputMenu)]
    public static void HardwareInput()
    {
        Menu.SetChecked(HardwareInputMenu, true);
        Menu.SetChecked(KeyboardInputMenu, false);
        
        Object.FindObjectOfType<InputMode>().SetInputMode(InputMode.InputModeType.Hardware);
    }

    [MenuItem(KeyboardInputMenu)]
    public static void KeyboardInput()
    {
        Menu.SetChecked(HardwareInputMenu, false);
        Menu.SetChecked(KeyboardInputMenu, true);
        
        Object.FindObjectOfType<InputMode>().SetInputMode(InputMode.InputModeType.Keyboard);
    }
}
