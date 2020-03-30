using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    private Animator anim;
    private Vector3 buttonPosFadeIn;
    private Vector3 buttonPosFadeOut;
    [SerializeField] private float boxScale = 20f;
    private float yOffset = 0.3f;
    private float slerpSpeed = 1f;
    private bool isFadingOut;
    
    // Reference.
    [SerializeField] private ButtonSystem _buttonSystem;

    private void Start()
    {
        // Start values.
        isFadingOut = false;
        buttonPosFadeIn = transform.position;
        // Fade out position.
        buttonPosFadeOut = new Vector3(
            transform.position.x,
            (transform.position.y - (yOffset * boxScale)),
            transform.position.z);

        if (anim == null)
        {
            anim = gameObject.AddComponent<Animator>();
        }
        else
        {
            anim = GetComponent<Animator>();
        }
        
        // Subscribe.
        _buttonSystem.StartFadeOut += UpdatePosition;
    }

    private void Update()
    {
        if (isFadingOut)
        {
            if (transform.position != buttonPosFadeOut)
            {
                UpdatePosition();
            }
        }
    }


    public void UpdatePosition()
    {
        transform.position = Vector3.Slerp(transform.position, buttonPosFadeOut, slerpSpeed * Time.deltaTime);
    }

    public void SetFadingOut(bool x)
    {
        isFadingOut = x;
    }

    public void PlayAnimation(string name)
    {
        anim.SetTrigger(name);
    }
}
