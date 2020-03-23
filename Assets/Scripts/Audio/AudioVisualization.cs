using UnityEngine;

public enum VizualizationMode
{
    None,
    Ring,
    Bar
} 

public class AudioVisualization : MonoBehaviour
{
    // ==============================================================================================='public' variables
    [SerializeField]private float emphasisMultiplier;
    [SerializeField]private float retractionSpeed;
    
    [SerializeField]private int amountOfSegments;
    [SerializeField]private float radius;
    [SerializeField]private float bufferSizeArea;
    [SerializeField]private float maxExtendLength;

    [SerializeField]private GameObject lineRendererPrefab;
    [SerializeField]private VizualizationMode visualizationMode;
    
    [SerializeField]private Gradient gradientA = new Gradient();
    
    [SerializeField]private AudioSource audioSource;
    
    // =============================================================================================== private variables 
    private int _bufferSampleSize = 8192;
    private float _samplePercentage = 0;
    
    private Gradient _currentColor = new Gradient();

    private float _sampleRate;
    
    private float[] _samples;
    private float[] _spectrum;
    private float[] _extendLengths;

    private LineRenderer[] _lineRenderers;
    private MusicControlledEffect _effect;
    
    // =========================================================================================================== Awake
    private void Awake()
    {
        _sampleRate = AudioSettings.outputSampleRate;
        _samples = new float[_bufferSampleSize];
        _spectrum = new float[_bufferSampleSize];

        _effect = GetComponent<MusicControlledEffect>();

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

    // ================================================================================================ Instantiate Ring
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

    // ================================================================================================= Instantiate Bar
    private void Bar()
    {
        
    }

    // ========================================================================================================== Update
    private void Update()
    {
        audioSource.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);

        CalculateEffects();
        
        if (visualizationMode == VizualizationMode.Ring)
        {
            UpdateExtend();
            UpdateRing();
        }
    }
    
    // ======================================================================================== check values for effects
    private void CalculateEffects()
    {
        const int spectrumNumberListen = 17;
        float spec = _spectrum[spectrumNumberListen];
        if (spec > 0.01)
        {
            _effect.StartEffect();
        }
        else
        {
             _effect.StopEffect();
        }
    }
    
    // ======================================================================================== Update length visualizer
    private void UpdateExtend()
    {
        int iteration = 0;
        int indexOnSpectrum = 0;
        int averageValue = (int) (Mathf.Abs(_samples.Length * _samplePercentage) / amountOfSegments);

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

    // ===================================================================================================== Update Ring
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

    // ==================================================================================================== Spacing Math
    private float Spacing(float rad)
    {
        float c = 2f * Mathf.PI * rad;
        float n = _lineRenderers.Length;
        return c / n;
    }
}
