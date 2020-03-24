using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // ============================================================================================= "private" variables
    [SerializeField] private Transform followObject;
    [SerializeField] private Vector3 offset;

    // ========================================================================================================== Update
    void Update()
    {
        transform.position = followObject.position + offset;
    }
}
