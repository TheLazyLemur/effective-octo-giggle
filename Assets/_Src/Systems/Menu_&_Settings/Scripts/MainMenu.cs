using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AsyncOperation asyncLoad;

    private void Start()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    public void StartGame()
    {
        FadeManager.Instance.FadeOut(5, Color.black, StartGameFunc);
       
    }

    public void StartGameFunc()
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
            Debug.Log("Here1");
        }
       var deload = SceneManager.UnloadSceneAsync(currentScene);
       
       while (!deload.isDone)
       {
           yield return null;
           Debug.Log("Here2");
       }
       
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}