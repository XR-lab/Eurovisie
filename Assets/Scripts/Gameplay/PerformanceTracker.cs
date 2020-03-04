using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Eurovision.Gameplay
{
    public class PerformanceTracker : MonoBehaviour
    {
        public Action OnPerformanceFull;

        [SerializeField] private int _pointsNeeded = 5;
        public bool PerformanceFull { get { return _performancePoints >= _pointsNeeded; } }

        private int _performancePoints;

        private void Start()
        {
            _performancePoints = 0;
        }

        public void AddPoints(int score)
        {
            _performancePoints += score;

            if (_performancePoints >= _pointsNeeded)
            {
                _performancePoints = _pointsNeeded;

                UpdateUI();

                if (OnPerformanceFull != null)
                    OnPerformanceFull.Invoke();

                ResetPerformancePoints();                 
            }

            UpdateUI();
        }

        void ResetPerformancePoints()
        {
            _performancePoints = 0;
        }

        // ToDo Implement UI
        private void UpdateUI()
        {
            float normalizedScore = (float)_performancePoints / (float)_pointsNeeded;
        }
    }
}

