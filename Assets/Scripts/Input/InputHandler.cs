using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eurovision.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        [SerializeField] private bool _superOn = false; // We may want to move this somewhere else

        public void UpdateInput(int inputData)
        {
            int buttonID = (inputData / 10) - 1;
            int dataState = inputData % 2; 
            
           _buttons[buttonID].UpdateButtonState(_superOn, dataState);
        }
    }    
}

