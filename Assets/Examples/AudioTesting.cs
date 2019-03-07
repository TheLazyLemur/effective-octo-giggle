using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTesting : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;

    public bool Test;
    
    private void Update()
    {
        if(!Test) return;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.instance.PlaySfx(buttonClick);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.instance.PlayMusic(music1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AudioManager.instance.PlayMusic(music2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AudioManager.instance.PlayMusicWithFade(music1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AudioManager.instance.PlayMusicWithFade(music2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            AudioManager.instance.PlayMusicWithCrossFade(music1, 3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            AudioManager.instance.PlayMusicWithCrossFade(music2, 3f);
        }
           
    }
}
