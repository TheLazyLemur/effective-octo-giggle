using UnityEngine;

namespace Assets._Src.Systems.Game_Management
{
    public class PlayerManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
