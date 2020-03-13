using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Random = System.Random;

namespace Eurovision.Karaoke
{
        [RequireComponent(typeof(PlayableDirector))]
        [RequireComponent(typeof(AudioSource))]
        public class KaraokeController : MonoBehaviour
        {
                [SerializeField] private TrackLibrary _trackLibrary;
                [SerializeField] private UnityEngine.UI.Text _uiTextPlayerOne;
                [SerializeField] private UnityEngine.UI.Text _uiTextPlayerTwo;
                
                private int _index = 0;
                private PlayableDirector _playableDirector;
                private LyricData _lyricsData;
                private TrackData _trackData;
                private void Awake()
                {
                        _playableDirector = GetComponent<PlayableDirector>();
                }

                private void Start()
                {
                        /*var newTrack = _trackLibrary.GetRandomTrack();
                        LoadTrack(newTrack);
                        KaraokeStart();*/
                }

                public void LoadSong(int ID)
                {
                        var newTrack = _trackLibrary.GetTrack(ID);
                        LoadTrack(newTrack);
                        KaraokeStart();
                }
                
                public void KaraokeStart()
                {
                        _index = 0;
                        _playableDirector.Play();
                }

                public void LyricsStart()
                {
                        UpdateUIText(_lyricsData.Artist + " - " + _lyricsData.Tracktitle); 
                }
                
                public void LyricsUpdate()
                {
                        UpdateUIText(_lyricsData.Lyrics[_index]);
                        _index++;

                        if (_index >= _lyricsData.Lyrics.Length)
                        {
                                _index = _lyricsData.Lyrics.Length - 1;
                                print("Lyrics end");
                        }
                }

                public void LyricsEnd()
                {
                        UpdateUIText(_lyricsData.Artist + " - " + _lyricsData.Tracktitle);  
                }

                public void LoadTrack(TrackData trackData)
                {
                        _trackData = trackData;

                        _lyricsData = JsonUtility.FromJson<LyricData>(_trackData.lyrics.text);
                        _playableDirector.playableAsset = _trackData.timelineAsset;
                }

                void UpdateUIText(string newText)
                {
                        _uiTextPlayerOne.text = newText;
                        _uiTextPlayerTwo.text = newText;
                }
        }
}
