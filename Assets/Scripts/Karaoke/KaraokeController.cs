using System;
using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
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
                [SerializeField] private TrackLibrary _trackLibrary; //currently isn't getting used but we can use it to make the song selection buttons instead of making the buttons in the inspector
                [SerializeField] private UnityEngine.UI.Text _uiTextPlayerOne;
                [SerializeField] private UnityEngine.UI.Text _uiTextPlayerTwo;
                [SerializeField] private GameObject _buttonPrefab;
                [SerializeField] private Transform _buttonParent;
                [SerializeField] private Transform originPosition;
                [SerializeField] private float Xoffset = -9f;
                [SerializeField] private float Yoffset = 5f;
                [SerializeField] private float Zoffset = 4.5f;
                
                private int _index = 0;
                private PlayableDirector _playableDirector;
                private LyricData _lyricsData;
                private TrackData _trackData;
                private void Awake()
                {
                        _playableDirector = GetComponent<PlayableDirector>();
                        MakeSongButtons();
                }

                private void MakeSongButtons()
                {
                        int length = _trackLibrary.Length;
                        for (int i = 0; i < length; i++)
                        {
                                Vector3 position = originPosition.position;
                                position.x += Xoffset + Mathf.Abs((Xoffset / 2) * (i % (length / 2)));
                                position.y += Yoffset + (-Yoffset * (i / (length / 2)));
                                position.z = -0.4f * Mathf.Pow(-2 + i % (length / 2), 2) + Zoffset; 
                                Quaternion rotation = new Quaternion();
                                GameObject button = Instantiate(_buttonPrefab, position, rotation, _buttonParent);
                                button.name = i.ToString();
                                TrackSelection selection = button.GetComponent<TrackSelection>();
                                selection.trackData = _trackLibrary.GetTrack(i);
                                button.GetComponent<SpriteRenderer>().sprite = selection.trackData.image;
                        }
                }
                
                private void Start()
                {
                        /*var newTrack = _trackLibrary.GetRandomTrack();
                        LoadTrack(newTrack);
                        KaraokeStart();*/
                }

                public void LoadSong(TrackData trackData)
                {
                        LoadTrack(trackData);
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
