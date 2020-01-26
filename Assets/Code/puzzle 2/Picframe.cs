using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picframe : InteractableBase
{
    public AudioSource source;
    public AudioClip clip;
void Start()
{
    Puzzle = Scene1Manager.SceneState.puzzle2;
}

    public override void DoClickedEvent()
    {
        if(Scene1Manager.Instance.state == Puzzle)
        {
            source.Stop();
            Subtitles.Instance.AssignDialogue("Seems she was a fan of space, strange at such a young age. I wonder when this picture was taken.", clip.length, clip, source);
            Destroy(this);
        }
    }
}