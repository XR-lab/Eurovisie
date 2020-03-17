using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private RectTransform edgeRect;
    [SerializeField] private Image progressbar;
    [SerializeField] private float maxScore;
    [SerializeField] private float speed;
    [SerializeField] private float score;
    
    private bool _ultimate;
    
    void Start()
    {
        score = 0;
        _ultimate = false;
        StartCoroutine(ScoreSettler());
    }

    private void Update()
    {
        //Here for testing will be replacte with a input script in the future
        if (Input.GetKeyDown(KeyCode.A) && score >= maxScore)
        {
            _ultimate = true;
            StartCoroutine(ScoreDialBack());
        }
    }

    public bool ActivateUltimate()
    {
        if (score >= maxScore)
        {
            _ultimate = true;
            StartCoroutine(ScoreDialBack());
        }
        return _ultimate;
    }

    IEnumerator ScoreSettler()
    {
        while (!_ultimate)
        {
            ScoreCalculation();
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(ScoreSettler());
    }

    IEnumerator ScoreDialBack()
    {
        while (_ultimate && score > 0.0f)
        {
            score -= Time.deltaTime * speed;
            ScoreCalculation();
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(ScoreDialBack());
    }

    private void ScoreCalculation()
    {
        float percentage = (score - 0) / (maxScore - 0);
        progressbar.fillAmount = percentage;
        edgeRect.anchorMin = new Vector2(progressbar.fillAmount, edgeRect.anchorMin.y);
        edgeRect.anchorMax = new Vector2(progressbar.fillAmount, edgeRect.anchorMax.y);
    }
}
