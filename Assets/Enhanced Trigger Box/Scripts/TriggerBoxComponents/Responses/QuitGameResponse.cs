using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace EnhancedTriggerbox.Component
{
    [AddComponentMenu("")]
    public class QuitGameResponse : ResponseComponent
    {
        public bool QuitToAnotherScene;
        public string Scene;


        public override void DrawInspectorGUI()
        {
#if UNITY_EDITOR

            QuitToAnotherScene = EditorGUILayout.Toggle(new GUIContent("Quit to scene?",
                "Tick this to quit to another scene. Otherwise the default quits the application"), QuitToAnotherScene);

            if (QuitToAnotherScene)
            {
                Scene = EditorGUILayout.TextField(new GUIContent("Scene name to quit to",
                    "Example tooltip"), Scene);
            }
#endif
        }


        public override void OnAwake()
        {
        }

        public EnhancedTriggerBox triggerbox;

        public override bool ExecuteAction()
        {
            triggerbox = GetComponent<EnhancedTriggerBox>();
            
           
            if (QuitToAnotherScene)
            {
                SceneManager.LoadScene(Scene);
                print("Loading scene " + Scene);
                return true;
            }
            print("Quit Game");
            Application.Quit();
            return true;
        }


        public override void Validation()
        {
        }
    }
}