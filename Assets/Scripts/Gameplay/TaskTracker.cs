using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Eurovision.Karaoke;

namespace Eurovision.Gameplay
{
    [RequireComponent(typeof(Eyetracker))]
    public class TaskTracker : MonoBehaviour
    {
        public event Action OnTaskComplete;

        [SerializeField] private float _unFillSpeed = 2;
        [SerializeField] private Image _progressImage;

        private Task _currentTask;

        private float _timer = 0;
        private Eyetracker _eyetracker;
        private TaskGenerator _taskGenerator;
        private PerformanceTracker _performanceTracker;
        private KaraokeController _karaokeController;
        private LookObject _endTarget;

        private void Awake()
        {
            _eyetracker = GetComponent<Eyetracker>();
            _taskGenerator = GetComponent<TaskGenerator>();
            _performanceTracker = GetComponent<PerformanceTracker>();
            _karaokeController = FindObjectOfType<KaraokeController>();
        }

        private void Start()
        {
            _currentTask = _taskGenerator.GenerateSongTask();
        }

        public void StartExperience()
        {
            _currentTask = _taskGenerator.GenerateTask();
            _currentTask.Targets[0].SetAsActiveObject();

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

                if (_currentTask.Targets.Contains(currentTarget))
                {
                    if (_timer <= 0)
                        TaskStart();
                    _endTarget = currentTarget;
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
            _currentTask.Targets[0].SetAsInActiveObject();


            _performanceTracker.AddPoints(score);

            if (OnTaskComplete != null) // currently is only used for when song selection is done
            {
                OnTaskComplete();
                GetTrackAndPlay(_endTarget); // may need to change to something that can link with the delegate
            }

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
            while (newTask.Targets == _currentTask.Targets);

            _currentTask = newTask;
            _currentTask.Targets[0].SetAsActiveObject();
        }

        private void UpdateProgressImage()
        {
            float normalizedProgress = _timer /  _currentTask.Duration;
            _progressImage.fillAmount = normalizedProgress;
        }

        private void GetTrackAndPlay(LookObject lookObject)
        {
            TrackData track = lookObject.transform.GetComponent<TrackSelection>().trackData;
            _karaokeController.LoadSong(track);
        }
    }
}
