using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
using Eurovision.Karaoke;
using UnityEngine;

public class TrackSelectionObject : LookObject
{
    [SerializeField] private TrackData _trackData;
    public TrackData trackData { get { return _trackData; } set { _trackData = value; } }

    public override void SetAsGettingLookedAt()
    {
        //transform.localScale = new Vector3(0.9f,0.9f,0.9f);
    }

    public override void SetAsNotGettingLookedAt()
    {
        //transform.localScale = Vector3.one;
    }
}
