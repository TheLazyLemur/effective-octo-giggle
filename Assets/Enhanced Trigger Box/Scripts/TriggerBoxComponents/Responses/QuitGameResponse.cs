using System.Collections;
using System.Collections.Generic;
using EnhancedTriggerbox.Component;
using UnityEngine;

namespace EnhancedTriggerbox.Component
{
    [AddComponentMenu("")]
    public class QuitGameResponse : ResponseComponent
    {
        public GameObject Example;

        public override bool ExecuteAction()
        {
            Debug.Log("Quit");
            return true;
        }
    }
}