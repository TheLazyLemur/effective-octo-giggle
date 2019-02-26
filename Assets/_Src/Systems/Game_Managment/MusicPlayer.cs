using UnityEngine;

namespace _LostBotanist
{
    public class MusicPlayer : MonoBehaviour
    {
        private void Awake()
        {
            var musicPlayers = FindObjectsOfType<MusicPlayer>();

            if (musicPlayers.Length > 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);
        }
    }
}