using UnityEngine;

public class SaveGameExample
{
    public string playerName = "Player";
    public int xp = 0;

    private static string _gameDataFileName = "data.json";

    private static SaveGameExample _instance;
    public static SaveGameExample Instance
    {
        get
        {
            if (_instance == null)
                Load();
            return _instance;
        }

    }

    public static void Save()
    {
        FileManager.Save(_gameDataFileName, _instance);
    }

    public static void Load()
    {
        _instance = FileManager.Load<SaveGameExample>(_gameDataFileName);
    }

}