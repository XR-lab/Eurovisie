using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
using UnityEngine;

namespace Eurovision.Input
{
    public class RandomButtonPresser : InputReader
    {
        private InputHandler _handler;
        private TaskTracker _tracker;
        [SerializeField] private List<int> _datas;
        private List<int> _effects;
        private List<float> _delays;
        [SerializeField] private int _minimumEffects = 1;
        [SerializeField] private int _maximumEffects = 4;
        [SerializeField] private float _setupCooldown = 2f;
        [SerializeField] private float _particleCooldown = 5f;
        [SerializeField] private float _minBetweenDelay = 0f;
        [SerializeField] private float _maxBetweenDelay = 0.5f;
    
        // Start is called before the first frame update
        void Start()
        {
            _handler = FindObjectOfType<InputHandler>();
            _tracker = FindObjectOfType<TaskTracker>();
            _tracker.OnTaskComplete += StartAI;
        }

        public void StartAI()
        {
            StartCoroutine(AI());
            _tracker.OnTaskComplete -= StartAI;
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < _datas.Count; i++)
            {
                ParseInput(_datas[i]);
            }
        }
        private IEnumerator AI()
        {
            _datas = new List<int>();
            while (true)
            {
                yield return new WaitForSeconds(_setupCooldown);
                StartRandomEffects();
                yield return new WaitForSeconds(_particleCooldown);
                StopEffects();
            }
        }

        public void StartRandomEffects()
        {
            int wantingEffects = Random.Range(_minimumEffects, _maximumEffects);
            List<int> availableNum = new List<int>(_handler.ButtonAmount);
            _effects = new List<int>(wantingEffects);
            _delays = new List<float>();
            for (int i = 0; i < availableNum.Capacity; i++)
            {
                availableNum.Add(i);
            }
            for (int i = 0; i < _effects.Capacity; i++)
            {
                int randNum = Random.Range(0, availableNum.Count);
                _effects.Add(availableNum[randNum]);
                availableNum.RemoveAt(randNum);
            }
            for (int i = 0; i < _effects.Count; i++)
            {
                float delay = Random.RandomRange(_minBetweenDelay, _maxBetweenDelay);
                _delays.Add(delay);
                StartCoroutine(ChangeEffectState(delay, i, true));
            }
            for (int i = 0; i < _effects.Count; i++)
            {
                StartCoroutine(ChangeEffectState(0f, i, false));
            }
            _datas.Clear();
        }

        private IEnumerator ChangeEffectState(float delay, int effectNum, bool state)
        {
            yield return new WaitForSeconds(delay);
            if (state)
            {
                _datas.Add((_effects[effectNum] + 1) * 10 + 1);
            }
            else
            {
                _datas[effectNum] = (_effects[effectNum] + 1) * 10;
                StopCoroutine(AI());
            }
        }
        
        public void StopEffects()
        {
            for (int i = 0; i < _effects.Count; i++)
            {
                StartCoroutine(ChangeEffectState(_delays[i], i, false));
            }
        }
    }
}
