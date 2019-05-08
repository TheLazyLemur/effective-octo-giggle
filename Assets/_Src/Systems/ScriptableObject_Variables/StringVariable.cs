using System;
using UnityEngine;

namespace Assets._Src.Systems.ScriptableObject_Variables
{
    [CreateAssetMenu]
    public class StringVariable : ScriptableObject
    {
        public string initialValue;
        [NonSerialized] public string RuntimeValue;

        public void OnAfterSerialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize()
        {
        }
    }
}