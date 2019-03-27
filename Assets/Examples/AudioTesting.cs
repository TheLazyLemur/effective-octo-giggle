using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTesting : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClick = null;
    [SerializeField] private AudioClip music1 = null;
    [SerializeField] private AudioClip music2 = null;

    public bool Test;
    
    private void Update()
    {
        if(!Test) return;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.Instance.PlaySfx(buttonClick);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.Instance.PlayMusic(music1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AudioManager.Instance.PlayMusic(music2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AudioManager.Instance.PlayMusicWithFade(music1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AudioManager.Instance.PlayMusicWithFade(music2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            AudioManager.Instance.PlayMusicWithCrossFade(music1, 3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            AudioManager.Instance.PlayMusicWithCrossFade(music2, 3f);
        }
           
    }
}
