using System;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public enum VizualizationMode
{
    Ring,
    Bar
} 

public class AudioVisualization : MonoBehaviour
{
    // <][L][O][N][E][>==============================================================================='public' variables
    [SerializeField]private int bufferSampleSize;
    [SerializeField]private float samplePercentage;
    [SerializeField]private float emphasisMultiplier;
    [SerializeField]private float retractionSpeed;
    
    [SerializeField]private int amountOfSegments;
    [SerializeField]private float radius;
    [SerializeField]private float bufferSizeArea;
    [SerializeField]private float maxExtendLength;

    [SerializeField]private GameObject lineRendererPrefab;
    [SerializeField]private Material lineRendererMaterial;
    [SerializeField]private VizualizationMode visualizationMode;
    
    [SerializeField]private Gradient gradientA = new Gradient();
    [SerializeField]private Gradient gradientB = new Gradient();
    
    [SerializeField]private AudioSource audioSource;
    
    // <][L][O][N][E][>=============================================================================== private variables 
    private Gradient _currentColor = new Gradient();

    private float _sampleRate;
    
    private float[] _samples;
    private float[] _spectrum;
    private float[] _extendLengths;

    private LineRenderer[] _lineRenderers;
    
    // <][L][O][N][E][>=========================================================================================== Awake
    private void Awake()
    {
        _sampleRate = AudioSettings.outputSampleRate;
        _samples = new float[bufferSampleSize];
        _spectrum = new float[bufferSampleSize];

        switch (visualizationMode)
        {
            case VizualizationMode.Ring:
                Ring();
                break;
            case VizualizationMode.Bar:
                Bar();
                break;
        }
    }

    // <][L][O][N][E][>================================================================================ Instantiate Ring
    private void Ring()
    {
        _extendLengths = new float[amountOfSegments+1];
        _lineRenderers = new LineRenderer[_extendLengths.Length];

        for (int i = 0; i < _lineRenderers.Length; i++)
        {
            GameObject gObj = Instantiate(lineRendererPrefab);
            gObj.transform.position = Vector3.zero;

            LineRenderer lineRenderer = gObj.GetComponent<LineRenderer>();
            lineRenderer.sharedMaterial = new Material(Shader.Find("Sprites/Default"));

            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            _lineRenderers[i] = lineRenderer;
        }
    }

    // <][L][O][N][E][>================================================================================= Instantiate Bar
    private void Bar()
    {
        
    }

    // <][L][O][N][E][>========================================================================================== Update
    private void Update()
    {
        audioSource.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        
        UpdateExtend();

        if (visualizationMode == VizualizationMode.Ring)
        {
            UpdateRing();
        }
    }
    
    // <][L][O][N][E][>========================================================================================== Update
    private void UpdateExtend()
    {
        int iteration = 0;
        int indexOnSpectrum = 0;
        int averageValue = (int) (Mathf.Abs(_samples.Length * samplePercentage) / amountOfSegments);

        if (averageValue < 1) {averageValue = 1;}

        while (iteration < amountOfSegments)
        {
            int iterationIndex = 0;
            float sumValueY = 0;

            while (iterationIndex < averageValue)
            {
                sumValueY += _spectrum[indexOnSpectrum];
                indexOnSpectrum++;
                iterationIndex++;
            }

            float y = sumValueY / averageValue * emphasisMultiplier;
            _extendLengths[iteration] -= retractionSpeed * Time.deltaTime;

            if (_extendLengths[iteration] < y)
            {
                _extendLengths[iteration] = y;
            }

            if (_extendLengths[iteration] > maxExtendLength)
            {
                _extendLengths[iteration] = maxExtendLength;
            }

            iteration++;
        }
    }

    // <][L][O][N][E][>===================================================================================== Update Ring
    private void UpdateRing()
    {
        for (int i = 0; i < _lineRenderers.Length; i++)
        {
            float t = i / (_lineRenderers.Length - 2f);
            float a = t * Mathf.PI * 2f;
            
            Vector2 direction = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
            float maxRadius = (radius + bufferSizeArea + _extendLengths[i]);
            
            _lineRenderers[i].SetPosition(0, direction * radius);
            _lineRenderers[i].SetPosition(1, direction * maxRadius);

            _lineRenderers[i].startWidth = Spacing(radius);
            _lineRenderers[i].endWidth = Spacing(maxRadius);

            _lineRenderers[i].colorGradient = gradientA;
            //_lineRenderers[i].startColor = gradientA.Evaluate(0);
            //_lineRenderers[i].endColor = gradientA.Evaluate(1);
            //_lineRenderers[i].endColor = gradientA.Evaluate((_extendLengths[i] - 1f) / (maxExtendLength - 1f));
        }
    }

    // <][L][O][N][E][>==================================================================================== Spacing Math
    private float Spacing(float radius)
    {
        float c = 2f * Mathf.PI * radius;
        float n = _lineRenderers.Length;
        return c / n;
    }
}
