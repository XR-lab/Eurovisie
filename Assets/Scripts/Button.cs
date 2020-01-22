using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eurovision.Input
{
    public class Button
    {
        public event Action OnButtonDown;
        public event Action OnButtonHold;
        public event Action OnButtonUp;
        public enum InputState
        {
            Down,
            Hold,
            Up,
        }
        private InputState _currentInputState = InputState.Up;
        private UnityEvent _event;
        
        public void UpdateButtonState(int data)
        {
            switch (_currentInputState)
            {
                case InputState.Down:
                    if (data == 1)
                    {
                        // new state is hold
                        _currentInputState = InputState.Hold;
                        if (OnButtonHold != null)
                            OnButtonHold();
                    }
                    else if (data == 0)
                    {
                        // new state is up
                        _currentInputState = InputState.Up;
                        if (OnButtonUp != null)
                            OnButtonUp();
                    }
                    break;
                
                case InputState.Hold:
                    if (data == 1)
                    {
                        // state stays Hold
                        // _currentInputState = InputState.Hold;
                        if (OnButtonHold != null)
                            OnButtonHold();
                    }
                    else if (data == 0)
                    {
                        // new state is up
                        _currentInputState = InputState.Up;
                        if (OnButtonUp != null)
                            OnButtonUp();
                    }
                    break;
                
                case InputState.Up:
                    if (data == 1)
                    {
                        // new state is down
                        _currentInputState = InputState.Down;
                        if (OnButtonDown != null)
                            OnButtonDown();
                    }
                    break;
            }
        }
    }    
}

