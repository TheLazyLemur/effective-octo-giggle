using _Src.Systems.EventSystem;
using UnityEngine;

public class Player_EventTest : MonoBehaviour
{
    private void OnEnable ()
    {
        EventManager.StartListening ("PlayerDeath", Death);
    }

    private void OnDisable ()
    {
        EventManager.StopListening ("PlayerDeath", Death);
    }

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.A))
            EventManager.TriggerEvent ("PlayerDeath");
    }

    private void Death ()
    {        
        print ("Player has died");
    }
}