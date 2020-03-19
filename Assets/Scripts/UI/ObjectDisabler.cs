using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
using Eurovision.Karaoke;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    //todo:
    //rename this script to something else that makes more sense
    [SerializeField] private TaskTracker _taskTracker;
    [SerializeField] private GameObject _object;
    
    void Start()
    {
        _taskTracker.OnTaskComplete += DisableObject;
    }
    private void DisableObject()
    {
        _object.SetActive(false);
        _taskTracker.OnTaskComplete -= DisableObject;
    }
}
