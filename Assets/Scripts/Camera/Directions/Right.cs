using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : Mover
{
    private bool _returning;
    public override void ObjectMover(Transform target, float distance, float maxDistance, Vector3 startPos)
    {
        if (target.position.x <= startPos.x + maxDistance && !_returning)
        {
            _returning = false;
            Moving(new Vector3(startPos.x + maxDistance,startPos.y,startPos.z), target);
        }
        else if(target.position.x > startPos.x + maxDistance||_returning)
        {
            _returning = true;
            Moving(startPos, target);
            if (target.position.x <= startPos.x)
            {
                _returning = false;
            }
        }
    }
}
