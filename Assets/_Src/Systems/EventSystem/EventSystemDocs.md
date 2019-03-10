# Event System Documentation

## Overview

Easy to use Event System.

## Implementation

    Create an empty game object in your scene called Event Manager and add the EventManager.cs script to it.  Once the Event Manager is in the scene you don't need to touch it again.

**When wanting to use an event in any script, use the following steps:**

1. Make sure to implement the following using statement:  
```using _Src.Systems.EventSystem```
2. Subscribe to the event in the same script that holds the Method that you are trying to call with an event:

```cs
private void OnEnable ()
{
    EventManager.StartListening ("EventName", MethodName);
}

private void OnDisable ()
{
    EventManager.StopListening("EventName", MethodName);
}

private void MethodName()
{
    //Do something
}

//EventManager is a static class so doesn't need to be referenced.
```

3. You can then call that event from any script as follows:

```cs
EventManager.TriggerEvent("EventName");
```

## Example Scene

If you wish to look at the example scene, navigate to _Src/Systems/EventSystem/Example/Scenes and open the EventsExample scene.

The **Player_EventTest.cs** script on the **Player** object in the scene allows you to call the **Death()** method on that script through the event system.  The event is called in the **Update()** of **Player_EventTest.cs** as follows:

```cs
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
```

Press **Play** in Unity, then press the **A** button on the keyboard to see the words `"Player has died"` output to the console.

    Just to clarify: the event can be called from any script in the game, it does not have to be called from the same script of the method you are trying to run - and because the EventManager is static you don't have to ever reference the script holding the method or the Event Manager.