using System.Collections;
using System.IO;
using System.Net;
using UnityEngine;

public class ExampleDownloader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("http://127.0.0.1:5500/Test.txt"));
        ImageToByteArrayFromFilePath(@"C:\b0b29f2f8e9854c.png");
    }


    public static byte[] ImageToByteArrayFromFilePath(string imagefilePath)
    {
        byte[] imageArray = File.ReadAllBytes(imagefilePath);
        Debug.Log(imageArray.Length);
        return imageArray;
    }


    private IEnumerator GetRequest(string uri)
    {
        using (var webRequest = new WebClient())
        {
            // Request and wait for the desired page.
            yield return webRequest;

            if (webRequest.IsBusy)
            {
                Debug.Log(": Error: " + webRequest.IsBusy);
            }
            else
            {
                var downloadData = webRequest.DownloadData("http://127.0.0.1:5500/Test.txt");
                File.WriteAllBytes(@"E:\Text.json", downloadData);
                
                var json = File.ReadAllText(@"E:\Text.json");
                                                                                          
                var saveObject = JsonUtility.FromJson<SaveSettingsObject>(json);
                
                Debug.Log(saveObject.SfxVolume);
                Debug.Log(saveObject.MusicVolume);
                Debug.Log(saveObject.MasterVolume);
            }
        }
    }
}