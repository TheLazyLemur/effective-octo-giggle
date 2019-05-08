using System;
using UnityEngine;

namespace Assets._Src.Systems.ScriptableObject_Variables
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
        public float initialValue;
        [NonSerialized] public float RuntimeValue;

        public void OnAfterSerialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize()
        {
        }
    }
}