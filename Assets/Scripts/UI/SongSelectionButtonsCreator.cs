using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
using Eurovision.Karaoke;
using UnityEngine;

public class SongSelectionButtonsCreator : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonParent;
    [SerializeField] private Transform _originPosition;
    [SerializeField] private float _Xoffset = -9f;
    [SerializeField] private float _Yoffset = 5f;
    [SerializeField] private float _Zoffset = 4.5f;
    [SerializeField] private float _ArcStrength = -0.4f;
    [SerializeField] private float _YrotationOffset = -30f;
    [SerializeField] private TrackLibrary _trackLibrary;
    [SerializeField] private TaskGenerator _taskGenerator;
    
    void Awake()
    {
       //MakeSongButtons();
    }

    private void MakeSongButtons() // currently only looks good with exactly 10 buttons
    {
        int length = _trackLibrary.Length;
        LookObject[] buttons = new LookObject[length];
        for (int i = 0; i < length; i++)
        {
 
     
            Vector3 position = _originPosition.position;
            position.x += _Xoffset + Mathf.Abs((_Xoffset / 2) * (i % (length / 2))); //Offset makes it start more on the left with the first item and then just adding a half of it each button to the right. reset it when we reach the halfway mark
            position.y += _Yoffset + (-_Yoffset * (i / (length / 2))); //Start with offset and once it reaches halfway mark remove the offset
            position.z += _ArcStrength * Mathf.Pow(-2 + i % (length / 2), 2) + _Zoffset; //Creates a parabola that starts 2 steps aside from the top and ends 2 steps on the other side. 
            Quaternion rotation = new Quaternion();
            Vector3 rotationEuler = rotation.eulerAngles;
            rotationEuler.y = _YrotationOffset + Mathf.Abs((_YrotationOffset / 2) * (i % (length / 2))); //Same idea as positionX only now with the Y rotation
            rotation = Quaternion.Euler(rotationEuler);
            GameObject button = Instantiate(_buttonPrefab, position, rotation, _buttonParent);
            TrackSelectionObject selection = button.GetComponent<TrackSelectionObject>();
            selection.trackData = _trackLibrary.GetTrack(i);
            button.GetComponent<SpriteRenderer>().sprite = selection.trackData.image;
            buttons[i] = button.GetComponent<LookObject>();
            
        }

        _taskGenerator.songTargets = buttons;
    }
}
