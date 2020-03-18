using UnityEngine;

namespace Eurovision.Gameplay
{
    [System.Serializable]
    public class Task
    {
        [SerializeField] private LookObject[] _targets;
        public LookObject[] Targets { get { return _targets; } }

        [SerializeField] private float _duration;
        public float Duration { get { return _duration; } }

        [SerializeField] private int _performancePoints = 1;
        public int PerformancePoints {  get { return _performancePoints; } }
        
        public bool IsComplete { get; set; }

        public Task(LookObject[] targets, float duration)
        {
            _targets = targets;
            _duration = duration;

            IsComplete = false;
        }
    }
}
