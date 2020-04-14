using System;
using System.Collections;
using System.Collections.Generic;
using Eurovision.Karaoke;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneResetter : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad = 0;
    [Tooltip("Drag @KaraokeSystem here.")]
    [SerializeField] private KaraokeController _karaokeController;
    [Tooltip("Amount of seconds to wait before restart.")]
    [SerializeField] private float _restartTime = 5f;
    private float _currentTime = 0f;
    private bool isRunningTimer = false;

    private void Start() {
        _karaokeController.SongEnded += StartTimer;
    }

    void Update()
    {
        if (isRunningTimer) {
            _currentTime += Time.deltaTime;
            Debug.Log(_currentTime);
            if (_currentTime >= _restartTime) {
                ResetScene();
                isRunningTimer = false;
            }
        }
    }

    private void StartTimer() {
        isRunningTimer = true;
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

    private void OnDestroy() {
        _karaokeController.SongEnded -= StartTimer;
    }
}
