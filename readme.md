# Game Template

A game skeleton for any future projects. Will consist of systems essential to most games made inside Unity.

## Framework documentation

### Index  

1. Audio manager.
2. Fade manager.
3. Event system.
4. Save system.

#### Audio Manager

##### AudioManager.cs

```cs
    //SFX callbacks
    public void PlaySfx(AudioClip clip)
    public void PlaySfx(AudioClip clip, float vol)  
    //Music callbacks
    public void PlayMusic(AudioClip clipToPlay)
    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1)
    public void PlayMusicWithCrossFade(AudioClip clip, float transitionTime)
```

To set up an audio object just add an empty game object to the scene, then add the audio manager to the game object. Thats all you need to do. The callbacks are :

- Sound Effects
  - Use public void PlaySfx(AudioClip clip) simply plays an sfx sound.
  - Use public void PlaySfx(AudioClip clip, float vol) you can choose a volume between 0 -1.  
- Music
  - Use public void PlayMusic(AudioClip clipToPlay) use this when there is no audio playing.
  - Use public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1) fade the first song to silent then there is a slight pause and new song fades in.
  - Use public void PlayMusicWithCrossFade(AudioClip clip, float transitionTime) fades music with no break in between, its a cross fade.

#### Screen Fade

##### ScreenFade.cs

```cs
    //Fade in
    private void FadeIn(float fadeTime)
    private void FadeIn(float fadeTime, Color fadeColor, Action func = null)
    //Fade out
    public void FadeOut(float fadeTime)
    public void FadeOut(float fadeTime, Color fadeColor, Action func = null)
```

To set up the fade object add a Canvas to the scene. Call is "Fade object" Then add a canvas group component to that same canvas. Then child an image to the Canvas, stretch it over the whole screen and then add FadeManager.cs. It should now look like this :  

![FadeManager](../ReadMeFiles/FadeManager.PNG)

The callbacks are :

- Fade In
  - Use private void FadeIn(float fadeTime) just select the time of the fade default color is black.
  - Use private void FadeIn(float fadeTime, Color fadeColor) to select a fade time and fade color
  - Use private void FadeIn(float fadeTime, Color fadeColor, Action func) to select a fade time and fade color and function to call once the fade is complete
- Fade out
  - The callback are all the same(use FadeOut instead).

#### Event System

##### Overview

Easy to use Event System.

##### Implementation

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

3.You can then call that event from any script as follows:

```cs
EventManager.TriggerEvent("EventName");
```

##### Example Scene

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
