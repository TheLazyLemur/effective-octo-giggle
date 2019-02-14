using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [FormerlySerializedAs("_masterSlider")] [SerializeField]
    private Slider masterSlider;

    [FormerlySerializedAs("_musicSlider")] [SerializeField]
    private Slider musicSlider;

    [FormerlySerializedAs("_sfxSlider")] [SerializeField]
    private Slider sfxSlider;

    private void Awake()
    {
        audioMixer.GetFloat("MasterVolume", out var masterVolume);
        MasterVolume(masterVolume);
        masterSlider.value = masterVolume;

        audioMixer.GetFloat("MusicVolume", out var musicVolume);
        MasterVolume(musicVolume);
        musicSlider.value = musicVolume;

        audioMixer.GetFloat("SFXVolume", out var sfxVolume);
        MasterVolume(sfxVolume);
        sfxSlider.value = sfxVolume;
    }


    public void MasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
        Debug.Log(value);
    }

    public void MusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", value);
        Debug.Log(value);
    }

    public void SfxVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", value);
        Debug.Log(value);
    }
}