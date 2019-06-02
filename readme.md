# Game Template

A game skeleton for any future projects. Will consist of systems essential to most games made inside Unity.

## Framework documentation

### Index  

1. [Audio Manager](#Audio-Manager)
2. [Fade Manager](#Screen-Fade)

### Audio Manager

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

### Screen Fade

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

![FadeManager](./ReadMeFiles/FadeManager.PNG)

The callbacks are :

- Fade In
  - Use private void FadeIn(float fadeTime) just select the time of the fade default color is black.
  - Use private void FadeIn(float fadeTime, Color fadeColor) to select a fade time and fade color
  - Use private void FadeIn(float fadeTime, Color fadeColor, Action func) to select a fade time and fade color and function to call once the fade is complete
- Fade Out
  - Use private void FadeOut(float fadeTime) just select the time of the fade default color is black.
  - Use private void FadeOut(float fadeTime, Color fadeColor) to select a fade time and fade color
  - Use private void FadeOut(float fadeTime, Color fadeColor, Action func) to select a fade time and fade color and function to call once the fade is complete