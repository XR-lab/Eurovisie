using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CommandSetCrowd : Command<BehaviorIds, CrowdBehaviorDTO>
{
    public override BehaviorIds Id => BehaviorIds.Crowd;
    private Animator _animator;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    public override void Execute(CrowdBehaviorDTO commadData)
    {
        _animator.SetTrigger(commadData.crowdHype);
    }
}
