using System;
using Assets._Src.Systems.Game_Management;
using UnityEngine;

//using OVR;

namespace Assets.Examples
{
    public class FadeTesting : MonoBehaviour
    {
        public bool Test;
        private FadeManager _fadeManager;

        private void Awake()
        {
            _fadeManager = FindObjectOfType<FadeManager>();
        }

        private void Update()
        {
            if (!Test) return;

            TestInput();
        }

        private void TestInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _fadeManager.FadeOut(1, Color.black);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _fadeManager.FadeIn(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _fadeManager.FadeOut(1, Color.white);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _fadeManager.FadeIn(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                _fadeManager.FadeOut(1, Color.yellow, TestFunction);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                _fadeManager.FadeIn(1, Color.yellow, TestFunction2);
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
}