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


//    public static void Main()
//    {
//        // Create a request using a URL that can receive a post.   
//        WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
//        // Set the Method property of the request to POST.  
//        request.Method = "POST";
//        // Create POST data and convert it to a byte array.  
//        string postData = "This is a test that posts this string to a Web server.";
//        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
//        // Set the ContentType property of the WebRequest.  
//        request.ContentType = "application/x-www-form-urlencoded";
//        // Set the ContentLength property of the WebRequest.  
//        request.ContentLength = byteArray.Length;
//        // Get the request stream.  
//        Stream dataStream = request.GetRequestStream();
//        // Write the data to the request stream.  
//        dataStream.Write(byteArray, 0, byteArray.Length);
//        // Close the Stream object.  
//        dataStream.Close();
//        // Get the response.  
//        WebResponse response = request.GetResponse();
//        // Display the status.  
//        Console.WriteLine(((HttpWebResponse) response).StatusDescription);
//        // Get the stream containing content returned by the server.  
//        dataStream = response.GetResponseStream();
//        // Open the stream using a StreamReader for easy access.  
//        StreamReader reader = new StreamReader(dataStream);
//        // Read the content.  
//        string responseFromServer = reader.ReadToEnd();
//        // Display the content.  
//        Console.WriteLine(responseFromServer);
//        // Clean up the streams.  
//        reader.Close();
//        dataStream.Close();
//        response.Close();
//    }
}