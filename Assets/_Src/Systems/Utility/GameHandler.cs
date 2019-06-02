using Assets._Src.Systems.Save_System;
using Assets._Src.Systems.Scripts;
using UnityEngine;

namespace Assets._Src.Systems.Utility
{
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
}