using UnityEngine;

namespace _JUSTIN.EventSystem.Scripts
{
    public class EventCreator : MonoBehaviour
    {
        private TestEvents _testEvents;

        private void Awake()
        {
            _testEvents = FindObjectOfType<TestEvents>();
        }

        private void OnEnable()
        {
            //SUBSCRIBING TO NON-STATIC EVENTS
            EventManager.StartListening("SpawnObjects", _testEvents.SpawnObjects);
            
            //SUBSCRIBING TO STATIC EVENTS
            EventManager.StartListening("DestroyObjects", TestEvents.DestroyObjects);
        }

        private void OnDisable()
        {
            //UN-SUBSCRIBING FROM NON-STATIC EVENTS
            EventManager.StopListening("SpawnObjects", _testEvents.SpawnObjects);
            
            //UN-SUBSCRIBING FROM STATIC EVENTS
            EventManager.StopListening("DestroyObjects", TestEvents.DestroyObjects);
        }
    }
}
