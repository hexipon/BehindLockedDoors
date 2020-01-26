using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : InteractableBase
{//change to suit open cupboard 
    [SerializeField]
    private readonly string keyID = "CuKey";


    private bool doorOpen = false;
    private float actionTimer = 0.0f;

    public AudioSource source;
    public AudioClip clip;

    public GameObject drawer;

    Vector3 secondPos;

    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle2;
        secondPos = new Vector3(drawer.transform.position.x, drawer.transform.position.y, drawer.transform.position.z + 5);
    }

    // Update is called once per frame
    void Update()
    {
        //draw open? instead
        if (doorOpen)
        {
            if (actionTimer < 1.0f)
            {
                actionTimer += Time.deltaTime;
                drawer.transform.position = Vector3.MoveTowards(drawer.transform.position, secondPos, 0.0045f);
            }
        }
    }

    public override void DoClickedEvent()
    {
        if (Inventory.Instance.ContainsItem(keyID))
        {
            doorOpen = true;
            Inventory.Instance.RemoveItem(keyID);
            Scene1Manager.Instance.state = Scene1Manager.SceneState.puzzle3;

        }
        else
        {
            if (!doorOpen)
            {
                source.Stop();
                Subtitles.Instance.AssignDialogue("Dammit", clip.length, clip, source);
                Objective.Instance.AssignObjective("Find the key");
            }

        }
    }
}