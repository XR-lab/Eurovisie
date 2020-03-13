using UnityEngine;
using UnityEngine.Events;

namespace Eurovision
{
    public class Effect : MonoBehaviour
    {
        [SerializeField] private UnityEvent _effectStart;
        [SerializeField] private UnityEvent _effectUpdate;
        [SerializeField] private UnityEvent _effectStop;

        public void OnEffectStart()
        {
            _effectStart?.Invoke();
        }

        public void OnEffectUpdate()
        {
            _effectUpdate?.Invoke();
        }

        public void OnEffectStop()
        {
            _effectStop?.Invoke();
        }
    }
}