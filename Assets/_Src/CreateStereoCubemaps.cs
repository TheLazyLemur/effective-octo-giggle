using UnityEngine;
using System.IO;
using Unity.Jobs;

class MyClass
{
    public void Encode()
    {
        var tempTex = CreateStereoCubemaps.Insatnce.tempTex;
        byte[] bytes = tempTex.EncodeToPNG();
        File.WriteAllBytes(@"C:\Users\lab\Documents\Games\file" + Time.frameCount + ".png", bytes);
    }
}

public struct Encode : IJob
{
    public void Execute()
    {
        var newclass = new MyClass();
        newclass.Encode();
    }
}

public class CreateStereoCubemaps : MonoBehaviour
{
    public static CreateStereoCubemaps Insatnce;
    public RenderTexture cubemapLeftEye;
    public RenderTexture cubemapRightEye;
    public RenderTexture equirect;
    public bool renderStereo = true;
    public float stereoSeparation = 0.064f;
    public bool captureToPNG;

    public Texture2D tempTex;

    private void Start()
    {
        Insatnce = this;
        tempTex = new Texture2D(equirect.width, equirect.height);
    }

    private Encode encode;

    void LateUpdate()
    {
        Camera cam = GetComponent<Camera>();


        if (renderStereo)
        {
            cam.stereoSeparation = stereoSeparation;
            cam.RenderToCubemap(cubemapLeftEye, 63, Camera.MonoOrStereoscopicEye.Left);
            cam.RenderToCubemap(cubemapRightEye, 63, Camera.MonoOrStereoscopicEye.Right);
        }
        else
        {
            cam.RenderToCubemap(cubemapLeftEye, 63, Camera.MonoOrStereoscopicEye.Mono);
        }

//optional: convert cubemaps to equirect

        if (equirect == null)
            return;

        RenderTexture oldRT = RenderTexture.active;

        cubemapLeftEye.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Right); // THIS MUST BE A UNITY BUG
        cubemapRightEye.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Left);

        RenderTexture.active = equirect;
        tempTex.ReadPixels(new Rect(0, 0, equirect.width, equirect.height), 0, 0);
        tempTex.Apply();


        Encode job = new Encode();


        var jobHandle = job.Schedule();
        jobHandle.Complete();


        RenderTexture.active = oldRT;
    }
}