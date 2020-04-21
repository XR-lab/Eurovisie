using System;
using System.Collections;
using System.Collections.Generic;
using Eurovision.Karaoke;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenHeadsetIcon : MonoBehaviour {
   // Sprite.
   [Tooltip("Drag image gameobject here.")]
   [SerializeField] private Image _currentSprite;
   [Tooltip("Fill this array with all the individual frames.")]
   [SerializeField] private Sprite[] _sprites;
   
   private int _spriteIndex = 0;
   private int _maxCount = 98;
   private float _waitTimer = 0f;
   [Tooltip("Wait this amount of time before restarting loop.")]
   [SerializeField] private float _waitForSeconds = 2f;
   private bool _isLooping = false;
   
   // Fading.
   private float _spriteAlpha = 0f;
   private float _fadeSpeed;
   [Tooltip("Fade in duration.")]
   [SerializeField] private float _fadeDuration = 3f;
   private float _desiredAlpha = 1f;
   private bool _isFadingSprite = false;
   
   // Timer.
   [Tooltip("How long after screen blur/ vignette to start fading in?")]
   [SerializeField] private float _startDelay = 3f;
   private float _timer = 0f;
   private bool _isIncreasingTimer = false;
   
   // References.
   [Tooltip("Drag @KaraokeSystem here.")]
   [SerializeField] private KaraokeController _karaokeController;
   
   private void Start() {
      _karaokeController.SongEnded += StartLooping;
      _karaokeController.SongEnded += StartFading;
      _karaokeController.SongEnded += StartTimer;
      _fadeSpeed = _desiredAlpha / _fadeDuration;
      _timer = 0f;
   }

   private void Update() {
      if (_isLooping && _timer >= _startDelay) {
         LoopSprites();
      }

      if (_isFadingSprite && _timer >= _startDelay) {
         FadeSprite();
      }

      if (_isIncreasingTimer) {
         if (_timer >= _startDelay) {
            _isIncreasingTimer = false;
         }
         
         _timer += Time.deltaTime;
      }

      // if (Input.GetKeyDown(KeyCode.Z)) {
      //    _isFadingSprite = true;
      // }
   }

   private void StartTimer() {
      _isIncreasingTimer = true;
   }

   private void StartLooping() {
      _isLooping = true;
   }
   
   private void StartFading() {
      _isFadingSprite = true;
   }

   private void IncreaseTimer() {
      if (_timer >= _startDelay) {
         _isIncreasingTimer = false;
         return;
      }
         
      _timer += Time.deltaTime;
   }

   private void LoopSprites() {
      if (_spriteIndex >= _maxCount - 1) {
         _waitTimer += Time.deltaTime;

         if (_waitTimer > _waitForSeconds) {
            _spriteIndex = 0;
            _waitTimer = 0f;
            _currentSprite.sprite = _sprites[_spriteIndex];
         }
      }

      if (_spriteIndex < _sprites.Length - 1)
      {
         _spriteIndex++;
         _currentSprite.sprite = _sprites[_spriteIndex];
      }
      
   }

   private void FadeSprite() {
      Color spriteColor = _currentSprite.color;
      if (spriteColor.a >= 1f) {
         _isFadingSprite = false;
         return;
      }
      
      _spriteAlpha += _fadeSpeed * Time.deltaTime;
      spriteColor = new Color(spriteColor.r, spriteColor.g, spriteColor.b, _spriteAlpha);
      _currentSprite.color = spriteColor;
   }

   private void OnDestroy() {
      _karaokeController.SongEnded -= StartLooping;
      _karaokeController.SongEnded -= StartFading;
   }
}
