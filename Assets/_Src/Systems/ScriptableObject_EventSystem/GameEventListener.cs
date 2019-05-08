using UnityEngine;
using UnityEngine.Events;

namespace Assets._Src.Systems.ScriptableObject_EventSystem
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private UnityEvent response;


        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }


        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }
    }
}