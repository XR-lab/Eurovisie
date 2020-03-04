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
        public Action<Task> OnTaskCancel;

        [SerializeField] private Image _progressImage;

        private Task _currentTask;

        private float _timer = 0;
        private Eyetracker _eyetracker;
        private TaskGenerator _taskGenerator;

        private void Awake()
        {
            _eyetracker = GetComponent<Eyetracker>();
            _taskGenerator = GetComponent<TaskGenerator>();
        }

        private void Start()
        {
            _currentTask = _taskGenerator.GenerateTask();
            _currentTask.Target.SetAsActiveObject();
        }

        private void Update()
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
            if (OnTaskCancel != null)
                OnTaskCancel.Invoke(_currentTask);

            _timer = 0;

            print("TaskCancel");
        }

        private void TaskComplete()
        {
            // maybe we should call these functions by the event?
            _currentTask.IsComplete = true;
            _currentTask.Target.SetAsInActiveObject();

            if (OnTaskComplete != null)
                OnTaskComplete.Invoke(_currentTask);

            Task newTask;
            do
                newTask = _taskGenerator.GenerateTask();
            while (newTask.Target == _currentTask.Target);

            _currentTask = newTask;
            _currentTask.Target.SetAsActiveObject();

            _timer = 0;

            UpdateProgressImage();

            print("TaskComplete");
        }

        private void UpdateProgressImage()
        {
            float normalizedProgress = _timer /  _currentTask.Duration;
            print(normalizedProgress);
            _progressImage.fillAmount = normalizedProgress;
        }
    }
}
