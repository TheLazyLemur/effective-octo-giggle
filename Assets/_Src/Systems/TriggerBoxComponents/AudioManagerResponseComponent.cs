using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace EnhancedTriggerbox.Component
{
    [AddComponentMenu("")]
    [Serializable]
    public class AudioManagerResponseComponent : ResponseComponent
    {
        public AudioClip _clipToPlay;
        public float _transitionTime;

        public enum MethodToCall
        {
            PlaySfx,
            PlayMusic,
            PlayMusicWithFade,
            PlayMusicWithCrossFade
        }

        public MethodToCall methodToCall;


        public override void DrawInspectorGUI()
        {
#if UNITY_EDITOR

            methodToCall = (MethodToCall) EditorGUILayout.EnumPopup(new GUIContent("", ""), methodToCall);

            _clipToPlay = (AudioClip) UnityEditor.EditorGUILayout.ObjectField(new GUIContent("Sound Clip",
                "The clip to play"), _clipToPlay, typeof(AudioClip), true);


            if (methodToCall == MethodToCall.PlayMusicWithFade || methodToCall == MethodToCall.PlayMusicWithCrossFade)
            {
                _transitionTime = EditorGUILayout.FloatField(new GUIContent("Fade time",
                    "The duration of fading in and out"), _transitionTime);
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
                case MethodToCall.PlaySfx:
                    AudioManager.instance.PlaySfx(_clipToPlay);
                    break;
                case MethodToCall.PlayMusic:
                    AudioManager.instance.PlayMusic(_clipToPlay);
                    break;
                case MethodToCall.PlayMusicWithFade:
                    AudioManager.instance.PlayMusicWithFade(_clipToPlay, 1.5f);
                    break;
                case MethodToCall.PlayMusicWithCrossFade:
                    AudioManager.instance.PlayMusicWithCrossFade(_clipToPlay, 1.5f);
                    break;
            }

            return true;
        }


        public override void Validation()
        {
        }
    }
}