using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eurovision.Input
{
    [System.Serializable]
    public class Button
    {
        [SerializeField]
        private Eurovision.Effect _effect;
        
        public enum InputState
        {
            Down,
            Hold,
            Up,
        }
        private InputState _currentInputState = InputState.Up;
        
        // TODO: Refactor into dictionary?
        public void UpdateButtonState(int data)
        {
            switch (_currentInputState)
            {
                case InputState.Down:
                    if (data == 1)
                    {
                        _currentInputState = InputState.Hold;
                        _effect.OnEffectUpdate();
                    }
                    else if (data == 0)
                    {
                        _currentInputState = InputState.Up;
                        _effect.OnEffectStop();
                    }
                    break;
                
                case InputState.Hold:
                    if (data == 1)
                    {
                        // state stays Hold
                        _effect.OnEffectUpdate();

                    }
                    else if (data == 0)
                    {
                        _currentInputState = InputState.Up;
                        _effect.OnEffectStop();
                    }
                    break;
                
                case InputState.Up:
                    if (data == 1)
                    {
                        _currentInputState = InputState.Down;
                        _effect.OnEffectStart();
                    }
                    break;
            }
        }
    }    
}

