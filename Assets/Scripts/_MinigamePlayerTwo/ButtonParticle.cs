using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonParticle : MonoBehaviour
{
    [SerializeField] private GameObject particleRainbow;
    [SerializeField] private GameObject particleNormal;
    [SerializeField] private float yOffset;

    public void InstantiateParticleRainbow()
    {
        GameObject burst = Instantiate(particleRainbow);
        Vector3 offset = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        burst.transform.position = offset;
    }
    
    public void InstantiateParticleNormal()
    {
        GameObject burst = Instantiate(particleNormal);
        Vector3 offset = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        burst.transform.position = offset;
    }
}
