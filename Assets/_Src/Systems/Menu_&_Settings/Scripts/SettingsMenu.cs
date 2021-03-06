﻿using System;
using Assets._Src.Systems.Save_System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets._Src.Systems.Scripts
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer = null;

        [FormerlySerializedAs("_masterSlider")] [SerializeField]
        public Slider masterSlider;

        [FormerlySerializedAs("_musicSlider")] [SerializeField]
        public Slider musicSlider;

        [FormerlySerializedAs("_sfxSlider")] [SerializeField]
        public Slider sfxSlider;

        public static SettingsMenu Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            var settingsLoad = new SaveSettingsSystem();

            try
            {
                settingsLoad.Load();
            }
            catch (Exception e)
            {
                Debug.Log(e + "Creating directory");
                settingsLoad.Save();
            }
        }

        public void SaveSettings()
        {
            var settingsLoad = new SaveSettingsSystem();
            settingsLoad.Save();
        }


        public void MasterVolume(float value)
        {
            audioMixer.SetFloat("MasterVolume", value);
            masterSlider.value = value;
        }

        public void MusicVolume(float value)
        {
            audioMixer.SetFloat("MusicVolume", value);
            musicSlider.value = value;
        }

        public void SfxVolume(float value)
        {
            audioMixer.SetFloat("SFXVolume", value);
            sfxSlider.value = value;
        }
    }
}