using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Karaoke
{
    [CreateAssetMenu(menuName = "Karaoke/TrackLibrary")]
    public class TrackLibrary : ScriptableObject
    {
        [SerializeField] private TrackData[] _tracks;

        public int Length
        {
            get { return _tracks.Length; }
        }

        public TrackData GetRandomTrack()
        {
            return _tracks[Random.Range(0, _tracks.Length)];
        }
    }
}

