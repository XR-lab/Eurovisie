using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public abstract void ObjectMover(Transform target, float distance, float maxDistance, Vector3 startPos);
}
