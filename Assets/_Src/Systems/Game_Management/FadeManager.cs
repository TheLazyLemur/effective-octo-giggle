using System;
using System.Collections;
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
                FadeIn(startFadeTime, startFadeColor);
            }
            else
            {
                fadeGroup.alpha = 0;
            }
        }

        public void FadeIn(float fadeTime)
        {
            FadeIn(fadeTime, fadeImage.color, null);
        }

        public void FadeIn(float fadeTime, Color fadeColor, Action func = null)
        {
            fadeImage.color = fadeColor;
            if (_fadeInCoroutine != null)
            {
                StopCoroutine(_fadeInCoroutine);
            }

            _fadeInCoroutine = StartCoroutine(UpdateFadeIn(fadeTime, func));
        }

        private IEnumerator UpdateFadeIn(float fadeTime, Action func)
        {
            Debug.Log("Started Fade in");
            var t = 0f;

            for (t = 0; t <= 1; t += Time.deltaTime / fadeTime)
            {
                fadeGroup.alpha = 1 - t;
                yield return null;
            }

            fadeGroup.alpha = 0;
            func?.Invoke();
        }

        public void FadeOut(float fadeTime)
        {
            FadeOut(fadeTime, fadeImage.color, null);
        }

        public void FadeOut(float fadeTime, Color fadeColor, Action func = null)
        {
            fadeImage.color = fadeColor;
            if (_fadeOutCoroutine != null)
            {
                StopCoroutine(_fadeOutCoroutine);
            }

            _fadeOutCoroutine = StartCoroutine(UpdateFadeOut(fadeTime, func));
        }

        private IEnumerator UpdateFadeOut(float fadeTime, Action func)
        {
            Debug.Log("Started Fade out");
            var t = 0f;

            for (t = 0; t <= 1; t += Time.deltaTime / fadeTime)
            {
                fadeGroup.alpha = t;
                yield return null;
            }

            fadeGroup.alpha = 1;
            func?.Invoke();
        }
    }
}