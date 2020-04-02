using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Mover
{
    private bool _returning;
    public override void ObjectMover(Transform target, float distance, float maxDistance, float speed,  Vector3 startPos)
    {
        if (target.position.x >= startPos.x - maxDistance && !_returning)
        {
            _returning = false;
            Moving(new Vector3(startPos.x - maxDistance,startPos.y,startPos.z), target,speed);
        }
        else if(target.position.x < startPos.x - maxDistance||_returning)
        {
            _returning = true;
            Moving(startPos, target,speed);
            if (target.position.x >= startPos.x)
            {
                _returning = false;
            }
        }
    }
}
