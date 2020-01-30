using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Input
{
    public class KeyboardInputReader : InputReader
    {
        private KeyCode[] _keycodes = new KeyCode[]
        {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9,
            KeyCode.Alpha0
        };

        private void Update()
        {
            for (int i = 0; i < _keycodes.Length; i++)
            {
                int data = UnityEngine.Input.GetKey(_keycodes[i]) ? ((i+1) * 10 + 1) : (i+1) * 10;
                ParseInput(data);
            }
        }
    }    
}

