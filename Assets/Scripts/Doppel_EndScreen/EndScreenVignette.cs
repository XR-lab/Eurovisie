using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Valve.VR;

public class EndScreenVignette : MonoBehaviour
{
    [SerializeField] private Volume m_Volume;
    [SerializeField] private Vignette m_Vignette;
    
    // Vignette fade variables.
    [SerializeField] private float desiredIntensity = 0.5f;
    [SerializeField] private float fadeDuration = 3f;
    private float fadeSpeed;
    [SerializeField] private bool isFading = false;
    

    private void Start() {
        fadeSpeed = desiredIntensity / fadeDuration;
        
        m_Volume = gameObject.GetComponent<Volume>();
        Vignette tmp;
        
        if (m_Volume.profile.TryGet<Vignette>(out tmp)) {
            m_Vignette = tmp;
        }
        
        if (m_Vignette.intensity.value <= 0f) {
            isFading = true;
        }
    }

    private void Update() {
        if (isFading) {
            FadeVignette();
        }
    }

    public void SetFading(bool t) {
        isFading = t;
    }

    private void FadeVignette() {
        if (m_Vignette.intensity.value >= desiredIntensity) {
            isFading = false;
            return;
        }
        
        m_Vignette.intensity.value += fadeSpeed * Time.deltaTime;
    }
}
