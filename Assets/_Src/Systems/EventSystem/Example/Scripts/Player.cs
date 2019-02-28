using UnityEngine;

namespace _Src.Systems.EventSystem.Scripts
{
    public class Player : MonoBehaviour
    {private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                EventManager.TriggerEvent("PlayerDeath");
        }

        public static void Death()
        {
            print("Death");
        }
    }
}
