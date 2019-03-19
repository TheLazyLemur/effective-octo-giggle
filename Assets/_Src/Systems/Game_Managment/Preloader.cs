using UnityEngine;
using UnityEngine.SceneManagement;

//using _LostBotanist.Scripts;

public class Preloader : MonoBehaviour
{
   [SerializeField] private CanvasGroup fadeGroup = null;
    private float loadTime;
    private float minimumLogoTime = 3f;


    private void Awake()
    {
        loadTime = 0;
    }

    private void Start()
    {

        fadeGroup.alpha = 1;
        
        //Preload game here
        
        
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
