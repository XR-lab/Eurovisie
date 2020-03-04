using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Gameplay
{
    [System.Serializable]
    public class Task
    {
        [SerializeField] private LookObject _target;
        public LookObject Target { get { return _target; } }

        [SerializeField] private float _duration;
        public float Duration { get { return _duration; } }

        private bool _isComplete = false;
        public bool IsComplete { get; set; }

        public Task(LookObject target, float duration)
        {
            _target = target;
            _duration = duration;

            _isComplete = false;
        }
    }
}
