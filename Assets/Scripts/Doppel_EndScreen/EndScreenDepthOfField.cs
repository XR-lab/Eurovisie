using System;
using System.Collections;
using System.Collections.Generic;
using Eurovision.Karaoke;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Valve.VR;

public class EndScreenDepthOfField : MonoBehaviour {
    [SerializeField] private Volume m_Volume;
    [SerializeField] private DepthOfField m_DepthOfField;
    
    // Depth of field fade variables.
    [SerializeField] private float desiredLength = 30f;
    [SerializeField] private float fadeDuration = 3f;
    private float fadeSpeed;
    [SerializeField] private bool isFading = false;
    
    // References.
    [SerializeField] private KaraokeController _karaokeController;
    

    private void Start() {
        _karaokeController.SongEnded += SetFading;
        fadeSpeed = desiredLength / fadeDuration;
        
        m_Volume = gameObject.GetComponent<Volume>();
        DepthOfField tmp;
        
        if (m_Volume.profile.TryGet<DepthOfField>(out tmp)) {
            m_DepthOfField = tmp;
        }

        // if (m_DepthOfField.focalLength.value <= 1f) {
        //     isFading = true;
        // }
    }

    private void Update() {
        if (isFading) {
            FadeDepthOfField();
        }
    }
    
    public void SetFading() {
        isFading = true;
    }

    private void FadeDepthOfField() {
        if (m_DepthOfField.focalLength.value >= desiredLength) {
            isFading = false;
            return;
        }
        
        m_DepthOfField.focalLength.value += fadeSpeed * Time.deltaTime;
    }
    
    private void OnDestroy() {
        _karaokeController.SongEnded -= SetFading;
    }
}