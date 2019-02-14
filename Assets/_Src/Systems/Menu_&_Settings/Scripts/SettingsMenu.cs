using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]private AudioMixer audioMixer;
    
    
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
