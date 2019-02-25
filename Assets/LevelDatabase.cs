using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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