using UnityEngine;
using System.IO;

public class FileManager
{
    public static T Load<T>(string filename) where T : new()
    {
        var filePath = Path.Combine(Application.persistentDataPath, filename);
        
        T output;

        if (File.Exists(filePath))
        {
            var dataAsJson = File.ReadAllText(filePath);
            output = JsonUtility.FromJson<T>(dataAsJson);
        }
        else
        {
            output = new T();
        }

        return output;
    }

    public static void Save<T>(string filename, T content)
    {
        var filePath = Path.Combine(Application.persistentDataPath, filename);

        var dataAsJson = JsonUtility.ToJson(content);
        File.WriteAllText(filePath, dataAsJson);

    }
    
}