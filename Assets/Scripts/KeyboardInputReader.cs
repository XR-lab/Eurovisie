using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Input
{
    public class KeyboardInputReader : InputReader
    {
        private void Update()
        {
            var data = (UnityEngine.Input.GetKey(KeyCode.A)) ? 11 : 10;
            ParseInput(data);
        }
    }    
}

