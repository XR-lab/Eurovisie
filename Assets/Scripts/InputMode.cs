using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Input
{
    //ToDo: InputModeType readable in editor
    public class InputMode : MonoBehaviour
    {
        public enum InputModeType
        {
            Hardware,
            Keyboard
        }
        private InputModeType _inputModeType;
        private InputReader _inputReader;
        
        public void SetInputMode(InputModeType inputModeType)
        {
            _inputModeType = inputModeType;
            
            if (_inputReader != null)
                DestroyImmediate(_inputReader);
            
            // ToDo: add and remove components needed for the input mode
            switch (_inputModeType)
            {
                case InputModeType.Hardware:
                    _inputReader = gameObject.AddComponent<SerialInputReader>();
                    break;
                
                case InputModeType.Keyboard:
                    _inputReader = gameObject.AddComponent<KeyboardInputReader>();
                    break;
            }
        }
    }
}
