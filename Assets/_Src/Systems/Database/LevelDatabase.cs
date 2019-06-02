using Assets._Src.Systems.Save_System;
using UnityEngine;

namespace Assets._Src.Systems.Database
{
    public class LevelDatabase : MonoBehaviour
    {
        public static LevelDatabase Instance;

        public int currentLevel { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            var loadedObject = new SaveProgressSystem();
            var saveProgressObject = loadedObject.Load() is SaveProgressObject
                ? (SaveProgressObject) loadedObject.Load()
                : default;

            currentLevel = saveProgressObject.LevelsUnlocked;
        }

        public void UnlockLevel()
        {
            currentLevel++;
        }
    }
}