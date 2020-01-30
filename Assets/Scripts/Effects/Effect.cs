using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            Debug.Log("Effect Start");
            if (_effectStart != null)
                _effectStart.Invoke();
        }

        public void OnEffectUpdate()
        {
            Debug.Log("Effect Update");
            if (_effectUpdate != null)
                _effectUpdate.Invoke();
        }

        public void OnEffectStop()
        {
            Debug.Log("Effect Stop");
            if (_effectStop != null)
                _effectStop.Invoke();
        }
    }
}