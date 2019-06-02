using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Src.Systems.EventSystem.Scripts
{
    public class EventManager : MonoBehaviour
    {
        private Dictionary<string, UnityEvent> _eventDictionary;

        private static EventManager _eventManager;

        private static EventManager instance
        {
            get
            {
                if (_eventManager)
                    return _eventManager;

                _eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (_eventManager != null) _eventManager.Init();

                return _eventManager;
            }                
        }

        private void Init()
        {
            if (_eventDictionary == null)            
                _eventDictionary = new Dictionary<string, UnityEvent>();            
        }

        public static void StartListening(string eventName, UnityAction listener)
        {
            UnityEvent thisEvent = null;
            if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))
                thisEvent.AddListener(listener);
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                instance._eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction listener)
        {
            if (_eventManager == null) return;
            UnityEvent thisEvent = null;
            if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))            
                thisEvent.RemoveListener(listener);            
        }

        public static void TriggerEvent(string eventName)
        {
            UnityEvent thisEvent = null;
            if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))            
                thisEvent.Invoke();            
        }
    }
}