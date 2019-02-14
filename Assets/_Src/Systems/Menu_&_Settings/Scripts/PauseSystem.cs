using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PauseSystem : MonoBehaviour
{
    public static PauseSystem Instance;
    public GameObject pausePanel;
    private bool _paused;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        _paused = true;
        
        //Trigger pause game event
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        _paused = false;
        
        //Trigger resume game event
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public bool IsPaused()
    {
        return _paused;
    }
}