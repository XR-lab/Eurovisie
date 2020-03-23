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
        [SerializeField]
        private Eurovision.Effect _superEffect;
        
        public enum InputState
        {
            Down,
            Hold,
            Up,
        }
        private InputState _currentInputState = InputState.Up;
        
        // TODO: Refactor into dictionary?
        public void UpdateButtonState(bool superOn, int data, ScoreBar[] scoreBars)
        {
            if (superOn && _currentInputState == InputState.Down)
            {
                UpdateEffect(_superEffect, data);
                for (int i = 0; i < scoreBars.Length; i++)
                {
                    scoreBars[i].ActivateUltimate();
                }
            }
            else
            {
                UpdateEffect(_effect, data);
            }
        }

        public void UpdateEffect(Eurovision.Effect effect, int data)
        {
            switch (_currentInputState)
            {
                case InputState.Down:
                    if (data == 1)
                    {
                        _currentInputState = InputState.Hold;
                        effect.OnEffectUpdate();
                    }
                    else if (data == 0)
                    {
                        _currentInputState = InputState.Up;
                        effect.OnEffectStop();
                    }
                    break;
                
                case InputState.Hold:
                    if (data == 1)
                    {
                        // state stays Hold
                        effect.OnEffectUpdate();

                    }
                    else if (data == 0)
                    {
                        _currentInputState = InputState.Up;
                        effect.OnEffectStop();
                    }
                    break;
                
                case InputState.Up:
                    if (data == 1)
                    {
                        _currentInputState = InputState.Down;
                        effect.OnEffectStart();
                    }
                    break;
            }
        }
    }    
}

