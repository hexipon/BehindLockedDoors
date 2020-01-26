using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : InteractableBase
{
    private bool triggerRadio=false;
    public AudioClip clip;
    public AudioSource source;
    public GameObject letter;
    public GameObject Radio;
    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle3;
    }
    public override void DoClickedEvent()
    {


            if (!triggerRadio && Scene1Manager.Instance.state == Puzzle)
            {
            //show letter on screen via gui, X to exit

            source.Stop();
            Subtitles.Instance.AssignDialogue(" ", clip.length, clip, source);
            triggerRadio = true;
            letter.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = (true);
            Radio.GetComponent<Radio>().TriggerSound();
            //start/trigger radio 
        }


    }
}
