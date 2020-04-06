using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    // ============================================================================================== "Public" variables
    [SerializeField] private VideoClip[] videoClips;
    
    // =============================================================================================== Private variables
    private VideoPlayer _videoPlayer;
    private int _index;
    
    // =========================================================================================================== Awake
    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    // ========================================================================================================== Update
    private void Update()
    {
        if (_videoPlayer.time >= _videoPlayer.length - 0.1)
        {
            _index++;
            _index %= videoClips.Length;
            _videoPlayer.clip = videoClips[_index];
            _videoPlayer.time = 0;
            _videoPlayer.Play();
        }
    }
}
