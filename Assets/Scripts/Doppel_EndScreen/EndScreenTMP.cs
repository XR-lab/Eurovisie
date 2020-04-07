using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenTMP : MonoBehaviour
{
    [SerializeField] private TextMeshPro[] m_TextArray;
    
    // Fade variables.
    private float fadeSpeed;
    [SerializeField] private float fadeDuration = 3f;
    [SerializeField] private float desiredAlpha = 100f;
    [SerializeField] private bool isFading = false;

    private void Start()
    {
        fadeSpeed = desiredAlpha / fadeDuration;
    }

    private void Update()
    {
        if (isFading)
        {
            FadeTextElements();
        }
    }

    private void FadeTextElements()
    {
        for (int i = 0; i < m_TextArray.Length; i++)
        {
            if (m_TextArray[i].alpha >= desiredAlpha)
            {
                isFading = false;
                return;
            }
            
            m_TextArray[i].alpha += fadeSpeed * Time.deltaTime;
        }
    }
}
