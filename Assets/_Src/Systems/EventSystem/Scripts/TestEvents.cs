using UnityEngine;

namespace _JUSTIN.EventSystem.Scripts
{
    public class TestEvents : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                EventManager.TriggerEvent("SpawnObjects");
            if (Input.GetKeyDown(KeyCode.D))
                EventManager.TriggerEvent("DestroyObjects");
        }

        public void SpawnObjects()
        {
            print("SpawnObjects");
        }

        public static void DestroyObjects()
        {
            print("DestroyObjects");
        }
    }
}