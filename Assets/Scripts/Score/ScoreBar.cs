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
    [SerializeField] private Animator _amalgamation;
    [SerializeField] private Animator _explosion;

    private bool _ultimate = false;
    private bool _used = false;
    public float _score;
    
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
            _amalgamation.SetTrigger("Emptying");
        }

        if (_score >= _maxScore && !_used)
        {
            _used = true;
            _amalgamation.SetTrigger("Activate");
            _explosion.SetTrigger("Activate");
        }
    }

    public void AddScore(float add)
    {
        if (_score + add > _maxScore)
        {
            _score = _maxScore;
            if (!_used)
            {
                _used = true;
                _amalgamation.SetTrigger("Activate");
                _explosion.SetTrigger("Activate");
            }
        }else 
        { 
            _score += add;
        }
    }
    public bool ActivateUltimate()
    {
        if (_score >= _maxScore)
        {
            _used = false;
            _ultimate = true;
            StartCoroutine(ScoreDialBack());
            _amalgamation.SetTrigger("Emptying");
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
