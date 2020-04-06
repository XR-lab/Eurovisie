using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightsMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _lightTransforms;
    [SerializeField] private List<Quaternion> _originRots;
    [SerializeField] private GameObject _lookpoint;
    [SerializeField] private float _originRot = 0f;
    [SerializeField] private float _maxDist = 40f;
    [SerializeField] private float _rotationStep = 2f;
    [SerializeField] private float _heightOffset;
    [SerializeField] private float _widthOffset;
    private event Action _movement;
    private List<Action> _movements = new List<Action>();
    private int index = 0;
    
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

        for (int i = 0; i < _lightTransforms.Count; i++)
        {
            _originRots.Add(_lightTransforms[i].rotation);
        }
        
        _movements.Add(MoveSideways);
        _movements.Add(MoveBackAndForth);
        _movement = _movements[index];
    }

    // Update is called once per frame
    void Update()
    {
        _movement();
    }

    public void ChangeMovement()
    {
        for (int i = 0; i < _lightTransforms.Count; i++)
        {
            _lightTransforms[i].rotation = _originRots[i];
        }
        //_movement = _movements[Random.Range(0, _movements.Count)];
        index++;
        _movement = _movements[index%_movements.Count];
    }

    private void MoveSideways()
    {
        if (_originRot + _widthOffset >= _maxDist + _widthOffset || _originRot + _widthOffset <= -_maxDist + _widthOffset)
        {
            _rotationStep *= -1;
        }
        
        _originRot += _rotationStep;
        
        for (int i = 0; i < _lightTransforms.Count; i++)
        {
            Vector3 rotation = _lightTransforms[i].rotation.eulerAngles;
            rotation.y += _rotationStep;
            //Debug.Log("Sideways = " + rotation.y);
            //_lightTransforms[i].rotation = Quaternion.Euler(rotation);
            _lightTransforms[i].rotation = Quaternion.Euler(new Vector3(rotation.x, _originRots[i].eulerAngles.y + _originRot + _widthOffset, rotation.z));
        }
    }
    
    private void MoveBackAndForth()
    {
        if (_originRot + _heightOffset >= _maxDist + _heightOffset || _originRot + _heightOffset <= -_maxDist + _heightOffset)
        {
            _rotationStep *= -1;
        }
        
        //_originRot += _rotationStep;
        
        for (int i = 0; i < _lightTransforms.Count; i++)
        {
            Vector3 rotation = _lightTransforms[i].rotation.eulerAngles;
            //rotation.x += _rotationStep;
            Debug.Log("What I should have: " + (_originRots[i].x + _originRot) + ", what i get: " + rotation.x);
            //Debug.Log("Back forth = " + rotation.x);
            //_lightTransforms[i].rotation = Quaternion.Euler(rotation);
            _lightTransforms[i].rotation = Quaternion.Euler(new Vector3(_originRots[i].x + _originRot + _heightOffset, rotation.y, rotation.z));
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
