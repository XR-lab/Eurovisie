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

        public void SetInputMode(InputModeType inputModeType)
        {
            _inputModeType = inputModeType;

            var activeReaders = GetComponents<InputReader>();
            foreach (var reader in activeReaders)
                DestroyImmediate(reader);
            
            
            switch (_inputModeType)
            {
                case InputModeType.Hardware:
                    gameObject.AddComponent<SerialInputReader>();
                    break;
                
                case InputModeType.Keyboard:
                    gameObject.AddComponent<KeyboardInputReader>();
                    break;
            }
        }
    }
}
