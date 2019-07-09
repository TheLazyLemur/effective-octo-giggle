using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Src.Systems.Game_Management
{
    public class FadeManager : MonoBehaviour
    {
        [Header("Fade references")] [SerializeField]
        private CanvasGroup fadeGroup = null;

        [SerializeField] private Image fadeImage = null;

        [Header("Fade variables")] [SerializeField]
        private bool startWithFade = true;

        [SerializeField] private Color startFadeColor = Color.black;
        [SerializeField] private float startFadeTime = 1.5f;

        private Coroutine _fadeInCoroutine;
        private Coroutine _fadeOutCoroutine;

        private void Awake()
        {
            if (startWithFade)
            {
                fadeGroup.alpha = 1;
                FadeIn(startFadeTime);
            }
            else
            {
                fadeGroup.alpha = 0;
            }
        }

        
        
        
        public void FadeIn(float fadeTime)
        {
            FadeIn(fadeTime,  null);
        }

        public void FadeIn(float fadeTime, List<Action> func)
        {
            if (_fadeInCoroutine != null)
            {
                StopCoroutine(_fadeInCoroutine);
            }

            _fadeInCoroutine = StartCoroutine(UpdateFadeIn(fadeTime, func));
        }

        public void FadeIn(float fadeTime, List<Action> before, List<Action> after)
        {
            if (_fadeInCoroutine != null)
            {
                StopCoroutine(_fadeInCoroutine);
            }

            _fadeInCoroutine = StartCoroutine(UpdateFadeIn(fadeTime, before, after));
        }
        
        
        
        
        
        
        
        
        
        
        

        private IEnumerator UpdateFadeIn(float fadeTime, List<Action> func)
        {
            Debug.Log("Started Fade in");
            var t = 0f;

            for (t = 0; t <= 1; t += Time.deltaTime / fadeTime)
            {
                fadeGroup.alpha = 1 - t;
                yield return null;
            }

            fadeGroup.alpha = 0;

            if (func != null)
            {
                foreach (var action in func)
                {
                    action?.Invoke();
                }
            }
        }
        
        
        private IEnumerator UpdateFadeIn(float fadeTime, List<Action> before, List<Action> after)
        {
            if (before != null)
            {
                foreach (var action in before)
                {
                    action?.Invoke();
                }
            }
            
            Debug.Log("Started Fade in");
            var t = 0f;

            for (t = 0; t <= 1; t += Time.deltaTime / fadeTime)
            {
                fadeGroup.alpha = 1 - t;
                yield return null;
            }

            fadeGroup.alpha = 0;

            if (after != null)
            {
                foreach (var action in after)
                {
                    action?.Invoke();
                }
            }
        }
        
        

        public void FadeOut(float fadeTime)
        {
            FadeOut(fadeTime,  null);
        }
        

        public void FadeOut(float fadeTime, List<Action> func)
        {
            if (_fadeOutCoroutine != null)
            {
                StopCoroutine(_fadeOutCoroutine);
            }

            _fadeOutCoroutine = StartCoroutine(UpdateFadeOut(fadeTime, func));
        }
        
        
        public void FadeOut(float fadeTime, List<Action> before, List<Action> after )
        {
            if (_fadeOutCoroutine != null)
            {
                StopCoroutine(_fadeOutCoroutine);
            }

            _fadeOutCoroutine = StartCoroutine(UpdateFadeOut(fadeTime, before, after));
        }
        
        
        private IEnumerator UpdateFadeOut(float fadeTime, List<Action> before, List<Action> after)
        {
            if (before != null)
            {
                foreach (var action in before)
                {
                    action?.Invoke();
                }
            }
            
            Debug.Log("Started Fade out");
            
            var t = 0f;

            for (t = 0; t <= 1; t += Time.deltaTime / fadeTime)
            {
                fadeGroup.alpha = t;
                yield return null;
            }

            fadeGroup.alpha = 1;

            if (after != null)
            {
                foreach (var action in after)
                {
                    action?.Invoke();
                }
            }
        }
        
        

        private IEnumerator UpdateFadeOut(float fadeTime, List<Action> func)
        {
            Debug.Log("Started Fade out");
            var t = 0f;

            for (t = 0; t <= 1; t += Time.deltaTime / fadeTime)
            {
                fadeGroup.alpha = t;
                yield return null;
            }

            fadeGroup.alpha = 1;

            if (func != null)
            {
                foreach (var action in func)
                {
                    action?.Invoke();
                }
            }
        }
    }
}