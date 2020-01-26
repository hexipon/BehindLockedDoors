using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : InteractableBase
{
    private bool PlayingSound = false;
    public AudioSource source;
    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle3;
    }

    public override void DoClickedEvent()
    {
        if (Scene1Manager.Instance.state == Puzzle)
        {
            //flip switch off and then on again
            //restart sound 
            if (PlayingSound) {
                source.Play();
                   }
                
        }
    }

    public void TriggerSound()
    {
        PlayingSound = true;
        source.Play();
        Objective.Instance.AssignObjective("It's starting!");
    }
}
