using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace Eurovision.Karaoke
{
    [CreateAssetMenu(menuName = "Karaoke/Create Karaoke Track")]
    public class TrackData : ScriptableObject
    {
        public TimelineAsset timelineAsset;
        public TextAsset lyrics;
    }
}

