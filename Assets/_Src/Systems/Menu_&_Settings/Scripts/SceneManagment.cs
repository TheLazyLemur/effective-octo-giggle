﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    private AsyncOperation _asyncLoad;
    public bool preloadOnStart;

    private void Start()
    {
        FadeManager.Instance.FadeIn(5);
        
        if (preloadOnStart)
            StartCoroutine(LoadYourAsyncScene());
    }

    public void StartGame()
    {
        FadeManager.Instance.FadeOut(5, Color.black, StartTheNextScene);
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
        var levelToLoad = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);
    }

    IEnumerator LoadYourAsyncScene()
    {
        var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        _asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);

        _asyncLoad.allowSceneActivation = false;

        while (!_asyncLoad.isDone)
        {
            yield return null;
        }

        var unload = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentScene);

        while (!unload.isDone)
        {
            yield return null;
        }
    }
}