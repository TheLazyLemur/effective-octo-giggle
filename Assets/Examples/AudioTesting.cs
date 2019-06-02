using Assets._Src.Systems.Game_Management;
using UnityEngine;

namespace Assets.Examples
{
    public class AudioTesting : MonoBehaviour
    {
        [SerializeField] private AudioClip buttonClick = null;
        [SerializeField] private AudioClip music1 = null;
        [SerializeField] private AudioClip music2 = null;

        public bool Test;
        private AudioManager _audioManager;

        private void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        private void Update()
        {
            if(!Test) return;
        
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _audioManager.PlaySfx(buttonClick);
            }
        
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _audioManager.PlayMusic(music1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _audioManager.PlayMusic(music2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _audioManager.PlayMusicWithFade(music1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                _audioManager.PlayMusicWithFade(music2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                _audioManager.PlayMusicWithCrossFade(music1, 3f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                _audioManager.PlayMusicWithCrossFade(music2, 3f);
            }
           
        }
    }
}
