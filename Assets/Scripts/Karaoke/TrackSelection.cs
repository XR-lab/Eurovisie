using System.Collections;
using System.Collections.Generic;
using Eurovision.Karaoke;
using UnityEngine;

public class TrackSelection : MonoBehaviour
{
    [SerializeField] private TrackData _trackData;
    public TrackData trackData { get { return _trackData; } set { _trackData = value; } }
}
