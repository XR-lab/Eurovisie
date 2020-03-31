using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : Mover
{
    public override void ObjectMover(Transform target, float distance, float maxDistance, Vector3 startPos)
    {
        if (target.position.y <= startPos.y - maxDistance)
        {
            target.position = startPos;
            return;
        }
        
        target.position = new Vector3(target.position.x, target.position.y - distance, target.position.z);
    }
}
