using System.IO;
using UnityEngine;

public struct SaveSettingsObject
{
    public float MasterVolume;
    public float MusicVolume;
    public float SfxVolume;
}

public struct SaveSettingsSystem : ISaveSystem
{
    private static readonly string SAVE_FOLDER = Application.persistentDataPath + "/SaveData/";

    public void Save()
    {
        if (!Directory.Exists(SAVE_FOLDER + "/Settings"))
        {
            Directory.CreateDirectory(SAVE_FOLDER + "/Settings");
        }


        var saveObject = new SaveSettingsObject()
        {
            MusicVolume = SettingsMenu.Instance.musicSlider.value,
            SfxVolume = SettingsMenu.Instance.sfxSlider.value,
            MasterVolume = SettingsMenu.Instance.masterSlider.value
        };

        var json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(SAVE_FOLDER + "/Settings" + "/settings" + ".json", json);
    }

    public object Load()
    {
        var dirInfo = new DirectoryInfo(SAVE_FOLDER + "/Settings");

        var files = dirInfo.GetFiles("*.json");

        FileInfo mostRecent = null;

        foreach (var fileInfo in files)
        {
            if (mostRecent == null)
            {
                mostRecent = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecent.LastWriteTime)
                    mostRecent = fileInfo;
            }
        }

        if (mostRecent == null) return null;


        var json = File.ReadAllText(mostRecent.FullName);
        var saveObject = JsonUtility.FromJson<SaveSettingsObject>(json);

        SettingsMenu.Instance.MasterVolume(saveObject.MasterVolume);
        SettingsMenu.Instance.SfxVolume(saveObject.SfxVolume);
        SettingsMenu.Instance.MusicVolume(saveObject.MusicVolume);

        return saveObject;
    }
}