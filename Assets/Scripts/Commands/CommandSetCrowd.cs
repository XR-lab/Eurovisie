using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CommandSetCrowd : Command<BehaviorIds, CrowdBehaviorDTO>
{
    public override BehaviorIds Id => BehaviorIds.Crowd;
    private Animator[] _animators;
    
    private void Start()
    {
        _animators = this.GetComponentsInChildren<Animator>();
    }

    public override void Execute(CrowdBehaviorDTO commadData)
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            _animators[i].SetFloat("Hype", commadData.crowdHype);
        }
    }
}
