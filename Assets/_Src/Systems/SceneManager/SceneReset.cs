using UnityEngine;
using _LostBotanist.Scripts;

public class SceneReset : MonoBehaviour
{
    private bool headSetOn = true;
    private float _duration = 5;
   
    
    private void Awake()
    {
     //   OVRManager.HMDUnmounted += HeadSetRemoved;
       // OVRManager.HMDMounted += HeadSetMounted;
    }

    private void Update()
    {
        if (headSetOn == false)
        {
            _duration -= Time.deltaTime;

            if (_duration <= 0)
            {
                SceneLoader.Instance.Reset();
            }
        }
        else if(headSetOn)
        {
            _duration = 5;
        }
    }

    private void HeadSetMounted()
    {
        headSetOn = true;
    }
    private void HeadSetRemoved()
    {
        headSetOn = false;
    }
}
