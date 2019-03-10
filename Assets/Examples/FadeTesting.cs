using System.Collections;
using System.Collections.Generic;
//using OVR;
using UnityEngine;

public class FadeTesting : MonoBehaviour
{
    public bool Test;
    
    private void Update()
    {
        if(!Test) return;
        
        TestInput();
    }

    private  void TestInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FadeManager.Instance.FadeOut(1, Color.black);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FadeManager.Instance.FadeIn(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FadeManager.Instance.FadeOut(1, Color.white);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FadeManager.Instance.FadeIn(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FadeManager.Instance.FadeOut(1, Color.yellow, TestFunction);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            FadeManager.Instance.FadeIn(1, Color.yellow, TestFunction2);
        }
    }

    private void TestFunction()
    {
        Debug.Log("Load next scene");
    }
    
    private void TestFunction2()
    {
        Debug.Log("Load next scene");
    }
}
