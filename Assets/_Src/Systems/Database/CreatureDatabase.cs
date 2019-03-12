using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureDatabase : MonoBehaviour
{
    public static CreatureDatabase Instance;

    public int creaturesUnlocked { get; private set; }

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
        
        creaturesUnlocked = saveProgressObject.CreaturesUnlocked;
    }

    public void UnlockCreature()
    {
        creaturesUnlocked++;
    }
}