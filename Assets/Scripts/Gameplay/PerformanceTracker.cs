using UnityEngine;
using UnityEngine.UI;
using System;

namespace Eurovision.Gameplay
{
    public class PerformanceTracker : MonoBehaviour
    {
        public Action onPerformanceFull;

        [SerializeField] private int _pointsNeeded = 5;
        [SerializeField] private Image _performanceBar; 

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

                onPerformanceFull?.Invoke();

                ResetPerformancePoints();                 
            }

            UpdateUI();
        }

        private void ResetPerformancePoints()
        {
            _performancePoints = 0;
        }

        private void UpdateUI()
        {
            float normalizedScore = (float)_performancePoints / (float)_pointsNeeded;
            _performanceBar.fillAmount = normalizedScore;
        }
    }
}

