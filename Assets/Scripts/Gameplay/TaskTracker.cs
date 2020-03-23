using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Eurovision.Gameplay
{
    [RequireComponent(typeof(Eyetracker))]
    public class TaskTracker : MonoBehaviour
    {
        public Action<Task> OnTaskComplete;

        [SerializeField] private float _unFillSpeed = 2;
        [SerializeField] private Image _progressImage;

        private Task _currentTask;

        private float _timer = 0;
        private Eyetracker _eyetracker;
        private TaskGenerator _taskGenerator;
        private ScoreBar _scoreBar;
        private PerformanceTracker _performanceTracker;

        private void Awake()
        {
            _eyetracker = GetComponent<Eyetracker>();
            _taskGenerator = GetComponent<TaskGenerator>();
            _scoreBar = GameObject.FindWithTag("ScoreUI").GetComponent<ScoreBar>();
            _performanceTracker = GetComponent<PerformanceTracker>();
        }

        private void Start()
        {
            /*
            _currentTask = _taskGenerator.GenerateTask();
            _currentTask.Target.SetAsActiveObject();

            _timer = 0;
            UpdateProgressImage();*/
        }

        public void StartExperience()
        {
            _currentTask = _taskGenerator.GenerateTask();
            _currentTask.Target.SetAsActiveObject();

            _timer = 0;
            UpdateProgressImage();
        }

        private void Update()
        {
            if (_currentTask != null)
            {
                LookObject currentTarget = _eyetracker.GetLookTarget();

                if (_currentTask.IsComplete)
                    return;

                if (currentTarget == null && _timer > 0)
                {
                    TaskCancel();
                    return;
                }
                else if (currentTarget == null)
                    return;

                if (currentTarget == _currentTask.Target)
                {
                    if (_timer <= 0)
                        TaskStart();

                    UpdateCurrentTask();
                }
            }
        }

        private void TaskStart()
        {
            _timer = 0;

            print("TaskStart");
        }

        private void UpdateCurrentTask()
        {
            _timer += Time.deltaTime;

            UpdateProgressImage();

            if (_timer >= _currentTask.Duration)
                TaskComplete();

            print("TaskUpdate");
        }

        private void TaskCancel()
        {
            _timer -= Time.deltaTime / _unFillSpeed;

            if (_timer <= 0)
                _timer = 0;

            UpdateProgressImage();

            print("TaskCancel");
        }

        private void TaskComplete()
        {
            // maybe we should call these functions by the event?
            int score = _currentTask.PerformancePoints;

            _currentTask.IsComplete = true;
            _currentTask.Target.SetAsInActiveObject();


            //_performanceTracker.AddPoints(score);
            if(!_scoreBar.Isactive()) _scoreBar.AddScore(score);

            if (OnTaskComplete != null)
                OnTaskComplete.Invoke(_currentTask);

            GenerateNewTask();

            _timer = 0;
            UpdateProgressImage();

            print("TaskComplete");
        }

        private void GenerateNewTask()
        {
            Task newTask;
            do
                newTask = _taskGenerator.GenerateTask();
            while (newTask.Target == _currentTask.Target);

            _currentTask = newTask;
            _currentTask.Target.SetAsActiveObject();
        }

        private void UpdateProgressImage()
        {
            float normalizedProgress = _timer /  _currentTask.Duration;
            _progressImage.fillAmount = normalizedProgress;
        }
    }
}
