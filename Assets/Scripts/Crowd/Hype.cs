using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hype : MonoBehaviour
{
    public float HypeMeter;
    Animator m_Animator;
    void Start()
    {
        //Get the animator, which you attach to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        m_Animator.SetFloat("Hype", HypeMeter);
    }
}
