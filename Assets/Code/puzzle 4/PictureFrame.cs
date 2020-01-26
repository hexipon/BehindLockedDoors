using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFrame : InteractableBase
{
    // Start is called before the first frame update
    private bool debounce=(false);
    public GameObject key;
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle4;
    }

    public override void DoClickedEvent()
    {
        if (Scene1Manager.Instance.state == Scene1Manager.SceneState.puzzle2)
        {
            source.Stop();
            Subtitles.Instance.AssignDialogue("Seems she was a fan of space, strange at such a young age. I wonder when this picture was taken.", clip.length, clip, source);
        }
        if (Scene1Manager.Instance.state == Puzzle)
        {
            if (!debounce)
            {
                debounce = true;
                key.SetActive(true);
                Objective.Instance.AssignObjective("Get the key from on top of the boxes");
            }
        }
    }
}
