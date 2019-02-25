using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    
    

    private void Start()
    {
        var progressSave = new SaveProgressSystem();

        var loadObject = progressSave.Load() is SaveProgressObject ? (SaveProgressObject) progressSave.Load() : default;
        var levelReached = loadObject.LevelsUnlocked;
        Debug.Log(levelReached);

        for (var i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    public void SelectLevel(int level)
    {
        switch (level)
        {
            case 1:
                //SceneManager.LoadScene("Level 1");
                Debug.Log("Loading scene 1");
                break;
            case 2:
                //SceneManager.LoadScene("Level 2");
                Debug.Log("Loading scene 2");
                break;
            case 3:
                //SceneManager.LoadScene("Level 3");
                Debug.Log("Loading scene 3");
                break;
            case 4 :
                //SceneManager.LoadScene("Level 4");
                Debug.Log("Loading scene 4");
                break;
            case 5 :
                //SceneManager.LoadScene("Level 5");
                Debug.Log("Loading scene 5");
                break;
        }
    }
}