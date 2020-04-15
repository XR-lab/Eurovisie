using UnityEngine;

namespace Eurovision.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        [SerializeField] private bool _superOn = false; // We may want to move this somewhere else
        [SerializeField] private ScoreBar _scoreBars;
        public int ButtonAmount { get { return _buttons.Length; } }

        private void Awake()
        {
            //_scoreBars = GameObject.FindGameObjectWithTag("ScoreUI").GetComponent<ScoreBar>();
        }

        public void UpdateInput(int inputData)
        {
            int buttonID = (inputData / 10) - 1;
            int dataState = inputData % 2;

            if (_scoreBars.ultimate)
            {
                _superOn = true;
            }
            else
            {
                _superOn = false;
            }
            _buttons[buttonID].UpdateButtonState(_superOn, dataState, _scoreBars);
        }

    }
}
