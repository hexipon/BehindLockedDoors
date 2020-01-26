using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landline : InteractableBase
{
    private bool played = false;
    public AudioSource source;
    public AudioSource sourceP;
    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    private bool ClipPlayed = false;
    private bool ClipPlayed1 = false;
    private bool ClipPlayed2 = false;
    private bool IsPlaying = false;
    private bool canPlay = false;

    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle2;
    }

    void Update()
    {

        if(!source.isPlaying && IsPlaying)
        {
            if (!ClipPlayed)
            {
                ClipPlayed = true;
                Subtitles.Instance.AssignDialogue("What’s going on Steve? If you don’t turn up in your office in the next twenty minutes, you’re going to have to think about getting a new job. You barely earnt this one anyway...", clip2.length, clip2, source);
            }
            else
            {
                if (!ClipPlayed1)
                {
                    ClipPlayed1 = true;
                    Subtitles.Instance.AssignDialogue("So that’s how it’s going to be, huh, Genwick? I’m not angry… I’m fuming! Oh well, you’re replaceable, there are plenty of other coders out there more talented than you anyway. I’m just surprised you’d let down you’re family like this, they were relying on you. Well, let me put it simply for you Steve, you’re fired. No longer working for me. Finito. Adios good sir and good riddance.", clip3.length, clip3, source);
                }
                else
                {
                    if(!ClipPlayed2)
                    {
                        ClipPlayed2 = true;
                        sourceP.Stop();
                        Subtitles.Instance.AssignDialogue("So I had a family… And a job that now I don’t have. Great. Why can’t I remember anything", clip4.length, clip4, sourceP);
                        Objective.Instance.AssignObjective("Explore for more clues");
                        IsPlaying = false;
                    }
                }
            }

        }

    }
    public override void DoClickedEvent()
    {
        if(Scene1Manager.Instance.state == Puzzle && !played && canPlay)
        {
            played = true;
            source.Stop();
            Objective.Instance.AssignObjective("Listen");
            Subtitles.Instance.AssignDialogue("Alright Genwick, you’re not normally late so we’ll count this as a warning. You best be on your way now and have a good reason for it too, this game isn’t going to make itself. Hurry up.", clip1.length, clip1, source);
            IsPlaying = true;
            //need this here or the outline will get stuck 
            //while sound isplaying loop else play childs laugh
        }
    }

    public void PlayRing()
    {
        source.PlayOneShot(clip, GameManager.Instance.GetNormalizedVolume());
        Debug.Log(GameManager.Instance.GetNormalizedVolume());
        if (Scene1Manager.Instance.state == Puzzle)
        {
            canPlay = true;
        }
            
    }
}
