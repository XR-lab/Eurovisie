using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Viewports
{
    // Working in Unity 2019.2 on OSX?
    // 1. Make sure you unselect auto graphics api in the player settings
    // 2. Drag and drop the metal down
    public class ActivateAllDisplays : MonoBehaviour
    {
        void Start ()
        {
            // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
            // Check if additional displays are available and activate each.
            
            for (int i = 0; i < Display.displays.Length; i++)
            {
                Display.displays[i].Activate(1024, 768, 60);
            }
        }
    }
}