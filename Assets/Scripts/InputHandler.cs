using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eurovision.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons = new Button[10];
        
        private void Awake()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i] = new Button();
            }
        }

        public void UpdateInput(int inputData)
        {
            int buttonID = (inputData / 10) - 1;
            int dataState = inputData % 2; 
            
            _buttons[buttonID].UpdateButtonState(dataState);
        }
    }    
}

