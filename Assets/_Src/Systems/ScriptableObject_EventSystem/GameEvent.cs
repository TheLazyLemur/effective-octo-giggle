using System.Collections.Generic;
using UnityEngine;

namespace Assets._Src.Systems.ScriptableObject_EventSystem
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> _listeners = new List<GameEventListener>();

        public void RegisterListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}