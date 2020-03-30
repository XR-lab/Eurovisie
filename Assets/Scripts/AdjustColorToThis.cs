using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustColorToThis : MonoBehaviour
{
	// =================================================================================== variables
	[SerializeField] private GameObject[] objects;
    private Material[] _mats;
	
    private void Awake()
    {
        _mats = new Material[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            _mats[i] = objects[i].GetComponent<Renderer>().material;
        }
    }

    private void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            _mats[i].color = GetComponent<Light>().color;
        }
    }
}
