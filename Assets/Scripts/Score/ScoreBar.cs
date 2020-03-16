using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private RectTransform edgeRect;
    [SerializeField] private Image progressbar;
    
    void Start()
    {
        StartCoroutine(LoadAsyncOperation(50,100));
    }

    IEnumerator LoadAsyncOperation(int score, int maxScore)
    {
        int percentage = (int)Math.Round((((double)score / (double)maxScore) * 100) / 100);
        float barScore = score / maxScore;
        Debug.Log(barScore);
        progressbar.fillAmount = barScore;
        edgeRect.anchorMin = new Vector2(progressbar.fillAmount,edgeRect.anchorMin.y );
        edgeRect.anchorMax = new Vector2(progressbar.fillAmount, edgeRect.anchorMax.y);
        yield return new WaitForEndOfFrame();
    }
}
