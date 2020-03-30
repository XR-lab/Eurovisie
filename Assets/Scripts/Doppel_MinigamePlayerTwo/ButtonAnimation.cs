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
    
    // Booleans.
    private bool isFadingOut;
    private bool isFadingIn;
    
    // Reference.
    [SerializeField] private ButtonSystem _buttonSystem;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
        // Start values.
        isFadingOut = false;
        buttonPosFadeIn = transform.position;
        
        // Fade out position.
        buttonPosFadeOut = new Vector3(
            transform.position.x,
            (transform.position.y - (yOffset * boxScale)),
            transform.position.z);

      
    }

    private void Update()
    {
        if (isFadingOut)
        {
            if (transform.position != buttonPosFadeOut)
            {
                UpdatePositionOut();
            }
        }

        if (isFadingIn)
        {
            if (transform.position != buttonPosFadeIn)
            {
                UpdatePositionIn();
            }
        }
    }


    public void UpdatePositionOut()
    {
        transform.position = Vector3.Slerp(transform.position, buttonPosFadeOut, slerpSpeed * Time.deltaTime);
    } 
    
    public void UpdatePositionIn()
    {
        transform.position = Vector3.Slerp(transform.position, buttonPosFadeIn, slerpSpeed * Time.deltaTime);
    }

    public void SetFadingOut(bool x)
    {
        isFadingOut = x;
    }

    public void SetFadingIn(bool x)
    {
        isFadingIn = x;
    }

    public void PlayAnimation(string name)
    {
        anim.SetTrigger(name);
    }
}
