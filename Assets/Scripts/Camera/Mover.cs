using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public abstract void ObjectMover(Transform target, float distance, float maxDistance, float speed,Vector3 startPos);

    public virtual void Moving(Vector3 target, Transform origin, float speed)
    {
        origin.position = Vector3.MoveTowards(origin.position, target, speed * Time.deltaTime);
    }
}
