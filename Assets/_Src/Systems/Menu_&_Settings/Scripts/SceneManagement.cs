using System;
using System.Collections;
using Assets._Src.Systems.Game_Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Src.Systems.Scripts
{
    public class SceneManagement : MonoBehaviour
    {
        private AsyncOperation _asyncLoad;
        public bool preloadOnStart;
        private  FadeManager _fadeManager;


        private void Awake()
        {
            _fadeManager = FindObjectOfType<FadeManager>();
        }

        private void Start()
        {
            _fadeManager.FadeIn(5);
        
            if (preloadOnStart)
                StartCoroutine(LoadYourAsyncScene());
        }

        public void StartGame()
        {
            _fadeManager.FadeOut(5, Color.black, StartTheNextScene);
            Debug.Log("Here");
        }

        public void StartPreloadingNextScene()
        {
            if (_asyncLoad != null) return;
        
            StartCoroutine(LoadYourAsyncScene());
        }

        public void StartTheNextScene()
        {
            _asyncLoad.allowSceneActivation = true;
        }
    
        public void ReloadCurrentScene()
        {
            var levelToLoad = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(levelToLoad);
        }

        IEnumerator LoadYourAsyncScene()
        {
            var currentScene = SceneManager.GetActiveScene();

            _asyncLoad = SceneManager.LoadSceneAsync(
                SceneManager.GetActiveScene().buildIndex + 1);

            _asyncLoad.allowSceneActivation = false;

            while (!_asyncLoad.isDone)
            {
                yield return null;
            }

            var unload = SceneManager.UnloadSceneAsync(currentScene);

            while (!unload.isDone)
            {
                yield return null;
            }
        }
    }
}