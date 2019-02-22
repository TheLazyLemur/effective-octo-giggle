using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LostBotanist.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Scene _currentScene;
        [SerializeField] private List<Scene> SceneLists = new List<Scene>();
        

        private int sceneCount = 0;


        public static SceneLoader Instance;

        private Coroutine _coroutine;

        private void Awake()
        {          
            var sceneLoaders = FindObjectsOfType<SceneLoader>();

            if (sceneLoaders.Length > 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);

            if (Instance == null)
                Instance = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ScreenFade.Instance.isFirstSplashScreen = false;
                LoadTheNextScene();
            }
        }


        private IEnumerator WaitForSceneDuration()
        {
            ScreenFade.Instance.FadeToClear();

            yield return new WaitForSeconds(_currentScene.SceneDuration);

            ScreenFade.Instance.FadeToBlack();
            var time = ScreenFade.Instance.fadeTime;

            if (time <= 0)
                time = 1;

            yield return new WaitForSeconds(time);

            if (SceneLists.Count <= 0)
            {
                Debug.Log("CREDITS ROLLING");
                yield break;
            }

            LoadTheNextScene();
            
        }

        public void LoadTheNextScene()
        {
            ScreenFade.Instance.FadeToBlack();

            if (_coroutine != null)
                StopCoroutine(_coroutine);


            _currentScene = SceneLists[sceneCount];
            sceneCount++;
            SceneManager.LoadScene(_currentScene.SceneName);
            _coroutine = StartCoroutine(WaitForSceneDuration());
            
            
        }

        public void Reset()
        {
            SceneManager.LoadScene("scene_Preloader");
            sceneCount = 0;
        }
    }

    [System.Serializable]
    public struct Scene
    {
        public string SceneName;
        public float SceneDuration;
    }
}