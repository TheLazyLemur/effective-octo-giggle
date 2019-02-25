using UnityEngine;

namespace _JUSTIN.EventSystem.Scripts
{
    public class EventCreator : MonoBehaviour
    {        
        private void OnEnable()
        {
            EventManager.StartListening("SpawnObjects", TestEvents.SpawnObjects);
            EventManager.StartListening("DestroyObjects", TestEvents.DestroyObjects);
        }

        private void OnDisable()
        {
            EventManager.StopListening("SpawnObjects", TestEvents.SpawnObjects);
            EventManager.StopListening("DestroyObjects", TestEvents.DestroyObjects);
        }
    }
}
