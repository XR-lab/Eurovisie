using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsColorChanger : MonoBehaviour
{
    [SerializeField] private List<Color32> _colors;
    [SerializeField] private List<Light> _lights;
    private int _colorPointer = -1;
    private Color32 newColor, oldColer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] lightObjects = GameObject.FindGameObjectsWithTag("Lighting");
        for (int i = 0; i < lightObjects.Length; i++)
        {
            Light light = lightObjects[i].GetComponent<Light>();
            if (!_lights.Contains(light))
            {
                _lights.Add(light);
            }
        }
        ChangeLightColors();
    }

    public void ChangeLightColors()
    {
        if (_lights.Count == 0 || _colors.Count == 0)
            return;
        
        /*_colorPointer++;
        if (_colorPointer >= _colors.Count)
        {
            _colorPointer = 0;
        }*/

        //Color32 newColor = _colors[_colorPointer];
        NewColor();
        while (newColor.Equals(oldColer))
        {
            NewColor();
        }
        oldColer = newColor;
        
        for (int i = 0; i < _lights.Count; i++)
        {
            _lights[i].color = newColor;
        }
    }

    private void NewColor()
    {
        newColor = _colors[Random.Range(0, _colors.Count)];
    }
}
