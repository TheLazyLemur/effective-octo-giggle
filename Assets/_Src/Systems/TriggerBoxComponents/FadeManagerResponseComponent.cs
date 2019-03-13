using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace EnhancedTriggerbox.Component
{
    [AddComponentMenu("")]
    [Serializable]
    public class FadeManagerResponseComponent : ResponseComponent
    {
        public float _fadeTime;
        public Color _color;
        public GameObject _objToCallMethodOn;
        public string _functionToCall;

        public enum MethodToCall
        {
            FadeIn,
            FadeInWithMethodCall,
            FadeOut,
            FadeOutWithMethodCall
        }

        public MethodToCall methodToCall;


        public override void DrawInspectorGUI()
        {
#if UNITY_EDITOR

            methodToCall = (MethodToCall) EditorGUILayout.EnumPopup(new GUIContent("",
                    ""),
                methodToCall);

            _fadeTime = EditorGUILayout.FloatField(new GUIContent("Fade time",
                "The duration of fading in and out"), _fadeTime);

            _color = EditorGUILayout.ColorField(new GUIContent("Fade Color",
                "The Color of the screen while fading"), _color);


            if (methodToCall == MethodToCall.FadeInWithMethodCall || methodToCall == MethodToCall.FadeOutWithMethodCall)
            {
                _objToCallMethodOn = (GameObject) UnityEditor.EditorGUILayout.ObjectField(new GUIContent(
                    "Game object to call method on",
                    "The method to be called once fade is finished."), _objToCallMethodOn, typeof(GameObject), true);

                _functionToCall = EditorGUILayout.TextField(new GUIContent("Method To Call",
                    "The duration of fading in and out"), _functionToCall);
            }

#endif
        }


        public override void OnAwake()
        {
        }


        public override bool ExecuteAction()
        {          
            switch (methodToCall)
            {
                case MethodToCall.FadeIn:
                    FadeManager.Instance.FadeIn(_fadeTime, _color);
                    break;
                case MethodToCall.FadeInWithMethodCall:
                    FadeManager.Instance.FadeIn(_fadeTime,_color);
                    _objToCallMethodOn.SendMessage(_functionToCall, _fadeTime);
                    break;
                case MethodToCall.FadeOut:
                    Debug.Log(_fadeTime);
                    FadeManager.Instance.FadeOut(_fadeTime, _color);
                    break;
                case MethodToCall.FadeOutWithMethodCall:
                    FadeManager.Instance.FadeOut(_fadeTime, _color);
                    _objToCallMethodOn.SendMessage(_functionToCall, _fadeTime);
                    break;
            }

            return true;
        }


        public override void Validation()
        {
        }
    }
}