using System;
using System.Collections;
using System.Collections.Generic;
using Eurovision.Input;
using UnityEditorInternal;
using UnityEngine;


namespace Eurovision.Input
{
    [RequireComponent(typeof(InputHandler))]
    public abstract class InputReader : MonoBehaviour
    {
        private InputHandler _inputHandler;

        private void Awake()
        { 
            _inputHandler = GetComponent<InputHandler>();
        }

        protected void ParseInput(int inputData)
        {
            _inputHandler.UpdateInput(inputData);
        }
    }
}

