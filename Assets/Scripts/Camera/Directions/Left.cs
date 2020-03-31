using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Mover
{
    public override void ObjectMover(Transform target, float distance, float maxDistance, Vector3 startPos)
    {
        if (target.position.x <= startPos.x - maxDistance)
        {
            target.position = startPos;
            return;
        }
        
        target.position = new Vector3(target.position.x - distance, target.position.y, target.position.z);
    }
}
