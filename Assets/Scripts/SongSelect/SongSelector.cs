using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Eurovision.Karaoke;

namespace Eurovision.Gameplay
{
    [RequireComponent(typeof(Eyetracker))]
    public class SongSelector : MonoBehaviour
    {

        [SerializeField] private float _unFillSpeed = 2;
        [SerializeField] private Image _progressImage;
        [SerializeField] private GameObject _songSelectionParent;
        [SerializeField] private float _progressTime;

        private float _timer = 0;
        private Eyetracker _eyetracker;
        private PerformanceTracker _performanceTracker;
        private KaraokeController _karaokeController;
        private TaskTracker _taskTracker;
        

        private void Awake()
        {
            _eyetracker = GetComponent<Eyetracker>();
            _performanceTracker = GetComponent<PerformanceTracker>();
            _karaokeController = FindObjectOfType<KaraokeController>();
            _taskTracker = FindObjectOfType<TaskTracker>();
        }

        private void Start()
        {
            _timer = 0;
            UpdateProgressImage();
        }

        private void Update()
        {
            LookButton currentTarget = _eyetracker.GetLookButton();
            
            if (currentTarget == null && _timer > 0)
            {
                TaskCancel();
                return;
            }
            else if (currentTarget == null)
                return;

            if (currentTarget)
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

            if (_timer >= _progressTime)
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
            _karaokeController.LoadSong(_eyetracker.GetLookButton().GetComponent<ButtonIDs>().ID);
            
            _timer = 0;
            UpdateProgressImage();
            
            _songSelectionParent.SetActive(false);
            _taskTracker.StartExperience();

            print("TaskComplete");
        }

        private void UpdateProgressImage()
        {
            float normalizedProgress = _timer / _progressTime;
            _progressImage.fillAmount = normalizedProgress;
        }
    }
}
