using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _lightTransforms;
    [SerializeField] private GameObject _lookpoint;
    private float _originRot = 0f;
    private float _maxDist = 40f;
    private float _rotationStep = 2f;
    private event Action _movement;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] lightObjects = GameObject.FindGameObjectsWithTag("Lighting");
        for (int i = 0; i < lightObjects.Length; i++)
        {
            Transform transform = lightObjects[i].transform;
            if (!_lightTransforms.Contains(transform))
            {
                _lightTransforms.Add(transform);
            }
        }

        _movement = MoveSideways;
    }

    // Update is called once per frame
    void Update()
    {
        _movement();
    }

    private void MoveSideways()
    {
        if (_originRot >= _maxDist || _originRot <= -_maxDist)
        {
            _rotationStep *= -1;
        }
        
        _originRot += _rotationStep;
        
        for (int i = 0; i < _lightTransforms.Count; i++)
        {
            Vector3 rotation = _lightTransforms[i].rotation.eulerAngles;
            rotation.x += _rotationStep;
            rotation.y = -90;
            //rotation.z = 90;
            //_lightTransforms[i].Rotate(0,rotation.y, 0);
            //_lightTransforms[i].rotation = Quaternion.Euler(-90, rotation.y, 0);
            _lightTransforms[i].rotation = Quaternion.Euler(rotation);
        }
    }
    
    private void FollowPoint()
    {
        float posX = _lookpoint.transform.position.x;
        if (posX >= _maxDist || posX <= -_maxDist)
        {
            _rotationStep *= -1;
        }
        
        posX += _rotationStep;
        _lookpoint.transform.position = new Vector3(posX, _lookpoint.transform.position.y,  _lookpoint.transform.position.z);
        for (int i = 0; i < _lightTransforms.Count; i++)
        {
            /*Vector3 rotation = _lightTransforms[i].rotation.eulerAngles;
            rotation.x += _rotationStep;
            rotation.y = -90;
            rotation.z = 90;
            //_lightTransforms[i].Rotate(0,rotation.y, 0);
            //_lightTransforms[i].rotation = Quaternion.Euler(-90, rotation.y, 0);
            _lightTransforms[i].rotation = Quaternion.Euler(rotation);*/
            _lightTransforms[i].LookAt(_lookpoint.transform);
        }
    }
}
