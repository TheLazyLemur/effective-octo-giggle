using System.Collections;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeGroup;

    [SerializeField] public float fadeTime;

    [HideInInspector]public bool isFirstSplashScreen = true;
    
    public static ScreenFade Instance;

    private void Awake()
    {
        var screenFader = FindObjectsOfType<ScreenFade>();

        if (screenFader.Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

        if (Instance == null)
            Instance = this;
        
        
        fadeGroup.interactable = false;
        fadeGroup.blocksRaycasts = false;
        fadeGroup.alpha = 1;

        FadeToClear();
    }


    [ContextMenu("Fade to black")]
    public void FadeToBlack()
    {
        StartCoroutine(FadeCanvasGroup(fadeGroup, 0, 1));
    }

    [ContextMenu("Fade to clear")]
    public void FadeToClear()
    {
        StartCoroutine(FadeCanvasGroup(fadeGroup, 1, 0));
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerptime = 1f)
    {
        var timeLerpStarted = Time.time;

        while (true)
        {
            var timeSinceStarted = Time.time - timeLerpStarted;
            var percentageComplete = timeSinceStarted / lerptime / fadeTime;

            var currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        if (isFirstSplashScreen)
        {
            FadeToBlack();
        }

        isFirstSplashScreen = false;

        Debug.Log("Fade Finished");
    }
}