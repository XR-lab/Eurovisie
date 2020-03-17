using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private RectTransform _edgeRect;
    [SerializeField] private Image _progressbar;
    [SerializeField] private float _maxScore;
    [SerializeField] private float _speed;

    private bool _ultimate;
    private float _score;
    
    void Start()
    {
        _score = 0;
        _ultimate = false;
        StartCoroutine(ScoreSettler());
    }

    private void Update()
    {
        //Here for testing will be replacte with a input script in the future
        if (Input.GetKeyDown(KeyCode.A) && _score >= _maxScore)
        {
            _ultimate = true;
            StartCoroutine(ScoreDialBack());
        }
    }

    public void AddScore(float add)
    {
        _score += add;
    }
    public bool ActivateUltimate()
    {
        if (_score >= _maxScore)
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
        while (_ultimate && _score > 0.0f)
        {
            _score -= Time.deltaTime * _speed;
            ScoreCalculation();
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(ScoreDialBack());
    }

    private void ScoreCalculation()
    {
        float percentage = (_score - 0) / (_maxScore - 0);
        _progressbar.fillAmount = percentage;
        _edgeRect.anchorMin = new Vector2(_progressbar.fillAmount, _edgeRect.anchorMin.y);
        _edgeRect.anchorMax = new Vector2(_progressbar.fillAmount, _edgeRect.anchorMax.y);
    }
}
