using UnityEngine;

public class AdjustColorToThis : MonoBehaviour
{
	// =================================================================================== variables
	[SerializeField] private GameObject[] objects;
    [SerializeField] private bool changeNeonStrips = false;
    [SerializeField] private Material neonMat;
    private Material[] _mats;
    private Light light;
	
    private void Awake()
    {
        _mats = new Material[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            _mats[i] = objects[i].GetComponent<Renderer>().material;
        }

        light = GetComponent<Light>();
    }

    private void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            _mats[i].color = light.color;
        }
        _mats[1].SetFloat("Strength", light.intensity);
        if (changeNeonStrips)
        {
            neonMat.SetColor("_EmissionColor", light.color);
            neonMat.color = light.color;
        }
    }
}
