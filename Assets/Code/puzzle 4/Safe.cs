using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : InteractableBase
{
    [SerializeField]
    private string keyID = "SKey";

    [SerializeField]
    private Transform rotationOrigin = null;

    public GameObject SDoor;

    private bool opensClockwise = false;
    private bool doorOpen = false;
    private float actionTimer = 0.0f;
    private float rotateMultiplier;

    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;

    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle4;
        rotateMultiplier = 90.0f * (opensClockwise ? 1.0f : -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            if (actionTimer < 1.0f)
            {
                actionTimer += Time.deltaTime;
                SDoor.transform.RotateAround(rotationOrigin.position, Vector3.up, Time.deltaTime * rotateMultiplier);
            }
        }
    }

    public override void DoClickedEvent()
    {
        if (Scene1Manager.Instance.state == Puzzle)
        {

            if (!Inventory.Instance.ContainsItem(keyID) && !doorOpen)
            {
                source.Stop();
                Subtitles.Instance.AssignDialogue("It’s never easy is it? Okay, where to look.", clip.length, clip, source);
            }
            else
            {
                doorOpen = true;
                Inventory.Instance.RemoveItem(keyID);

                source.Stop();
                Subtitles.Instance.AssignDialogue("Savings to move. We’re close. A few more shifts. Only use when necessary. Do I take it ? ", clip2.length, clip, source);
                Objective.Instance.AssignObjective("Do I take the money?");

                //need this here or the outline will get stuck 

                List<Material> editMaterials = new List<Material>();
                meshRenderer.GetMaterials(editMaterials);
                if (editMaterials.Count > 1)
                {

                    editMaterials.RemoveAt(editMaterials.Count - 1);

                    meshRenderer.materials = editMaterials.ToArray();
                }
                //Scene1Manager.Instance.state = Scene1Manager.SceneState.endGame;
            }
        }
    }
}
