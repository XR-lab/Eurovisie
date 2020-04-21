using System;
using System.Collections;
using System.Collections.Generic;
using Eurovision.Karaoke;
using TMPro;
using UnityEngine;

public class EndScreenTMP : MonoBehaviour {
    [SerializeField] private GameObject[] m_TextArray;
    
    // Fade variables.
    private float fadeSpeed;
    [SerializeField] private float fadeDuration = 3f;
    [SerializeField] private float desiredAlpha = 1f;
    [SerializeField] private float startDelay = 3f;
    [SerializeField] private float timer;
    [SerializeField] private bool isFading;
    
    // References.
    [SerializeField] private KaraokeController _karaokeController;

    private void Start() {
        fadeSpeed = desiredAlpha / fadeDuration;
        _karaokeController.SongEnded += StartFadeIn;

        timer = 0f;
    }

    private void Update() {
        if (isFading) {
            FadeTextElements();
        }
    }

    private void StartFadeIn() {
        isFading = true;
    }

    private void FadeTextElements() {
        for (int i = 0; i < m_TextArray.Length; i++) {
            var tmp = m_TextArray[i].GetComponent<TextMeshProUGUI>();
            Color color = new Color();
            

            if (tmp.color.a >= desiredAlpha) {
                isFading = false;
                return;
            }

            timer += Time.deltaTime;
            if (timer >= startDelay) {
                color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, tmp.color.a);
                color.a += fadeSpeed * Time.deltaTime;
                tmp.color = color;
            }
        }
    }

    private void OnDestroy() {
        _karaokeController.SongEnded -= StartFadeIn;
    }
}
