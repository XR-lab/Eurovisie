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

        [SerializeField] private int _performancePoints = 0;
        public int PerformancePoints {  get { return _performancePoints; } }

        public bool _isSong;
        
        public bool IsComplete { get; set; }

        public Task(LookObject[] targets, float duration, bool song, int pointValue)
        {
            _performancePoints = pointValue;
            _targets = targets;
            _duration = duration;
            _isSong = song;
            IsComplete = false;
        }
    }
}
