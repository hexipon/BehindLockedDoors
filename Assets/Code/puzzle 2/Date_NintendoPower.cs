using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date_NintendoPower : InteractableBase
{
    public AudioSource source;
    public AudioClip clip;
    public GameObject phone;
    private bool RingPlayed = false;
    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle2;
    }

    public override void DoClickedEvent()
    {
        Debug.Log(Scene1Manager.Instance.state == Puzzle);
        if (Scene1Manager.Instance.state == Puzzle)
        {

            //show on screen for set time the go into inventory with thumbnail date
            source.Stop();
            Subtitles.Instance.AssignDialogue("Nintendo, the next big thing huh? Their NES is a huge strive in gaming.Wow, August 1988 huh? Must be the newest issue.", clip.length, clip, source);
            if (!RingPlayed)
            {
                Objective.Instance.AssignObjective("Answer the phone");
                RingPlayed = true;
                phone.GetComponent<Landline>().PlayRing();
            }
        }
            
           
    }
}
