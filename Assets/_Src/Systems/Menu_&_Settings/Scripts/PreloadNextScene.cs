using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadNextScene : MonoBehaviour
{
    private AsyncOperation asyncLoad;
    public bool preloadOnStart;

    private void Start()
    {
        if (preloadOnStart)
            StartCoroutine(LoadYourAsyncScene());
    }

    public void StartGame()
    {
        FadeManager.Instance.FadeOut(5, Color.black, LoadTheNextScene);
        Debug.Log("Here");
    }

    public void StartPreloading()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    public void LoadTheNextScene()
    {
        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator LoadYourAsyncScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        var deload = SceneManager.UnloadSceneAsync(currentScene);

        while (!deload.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}