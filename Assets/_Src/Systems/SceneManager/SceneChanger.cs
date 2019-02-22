using UnityEngine;

namespace _LostBotanist.Scripts
{
    public class SceneChanger : MonoBehaviour
    {
        private bool _sceneChanged;

        void Update()
        {
          //  if (OVRInput.GetDown(OVRInput.RawButton.A) && _sceneChanged == false)
           // {
                _sceneChanged = true;
                ScreenFade.Instance.isFirstSplashScreen = false;
                SceneLoader.Instance.LoadTheNextScene();
                Invoke(nameof(DisableBool), 0.5f);
          //  }
        }

        void DisableBool()
        {
            _sceneChanged = false;
        }
    }
}