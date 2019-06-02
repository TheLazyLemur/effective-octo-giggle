using System.Collections;
using UnityEngine;

//using _LostBotanist.Scripts;

namespace Assets._Src.Systems.Game_Management
{
    public class Preloader : MonoBehaviour
    {
        [SerializeField] private CanvasGroup fadeGroup = null;
        private float loadTime;
        private float minimumLogoTime = 10f;

        private AsyncOperation asyncLoad;

    
        private void Start()
        {
            fadeGroup.alpha = 1;

            //Preload game here
            StartCoroutine(LoadYourAsyncScene());

            //if load time is very fast give a tiny buffer to see logo
            if (Time.time < minimumLogoTime)
                loadTime = minimumLogoTime;
            else
                loadTime = Time.time;
        }

        private void Update()
        {
            //Fade in
            if (Time.time < minimumLogoTime)
            {
                fadeGroup.alpha = 1 - Time.time;
            }

            //Fade out
            if (!(Time.time > minimumLogoTime) || loadTime == 0) return;

            fadeGroup.alpha = Time.time - minimumLogoTime;
            if (fadeGroup.alpha >= 1)
            {
                asyncLoad.allowSceneActivation = true;
            }
        }

        IEnumerator LoadYourAsyncScene()
        {
            var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
            asyncLoad.allowSceneActivation = false;
            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            var deload = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentScene);

            while (!deload.isDone)
            {
                yield return null;
            }
        }
    }
}