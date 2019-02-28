using UnityEngine;

namespace _Src.Systems.EventSystem.Scripts
{
    public class EventCreator : MonoBehaviour
    {
        private void OnEnable()
        {
            //EXAMPLE CODE: SUBSCRIBE TO EVENTS
            
            /*            
            EventManager.StartListening("SpawnObjects", TestEvents.SpawnObjects);
            
            EventManager.StartListening("DestroyObjects", TestEvents.DestroyObjects);
            
            EventManager.StartListening("PlayerDeath", Player.Death);
             */
        }

        private void OnDisable()
        {
            // EXAMPLE CODE: UNSUBSCRIBE FROM EVENTS
            
            /*
            EventManager.StopListening("SpawnObjects", TestEvents.SpawnObjects);

            EventManager.StopListening("DestroyObjects", TestEvents.DestroyObjects);

            EventManager.StopListening("PlayerDeath", Player.Death);
            */
        }
    }
}