using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseSystem.Instance.IsPaused())
        {
            PauseSystem.Instance.PauseGame();
        }
    }

    public void SaveGame()
    {
        var saveGame = new SaveGame();
        
        saveGame.Save();
    }
}