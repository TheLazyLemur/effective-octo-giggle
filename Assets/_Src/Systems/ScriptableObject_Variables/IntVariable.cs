using System;
using UnityEngine;

namespace Assets._Src.Systems.ScriptableObject_Variables
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject
    {
        public int initialValue;
        [NonSerialized] public int RuntimeValue;

        public void OnAfterSerialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize()
        {
            
        }
    }
}