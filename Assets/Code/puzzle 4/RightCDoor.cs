using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCDoor : InteractableBase
{
    [SerializeField]
    private Transform rotationOrigin = null;

    [SerializeField]
    private bool opensClockwise = false;
    private bool doorOpen = false;
    private float actionTimer = 0.0f;
    private float rotateMultiplier;

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
                transform.RotateAround(rotationOrigin.position, Vector3.up, Time.deltaTime * rotateMultiplier);
            }
        }
        else
        {
            if (actionTimer > 0.0f)
            {
                actionTimer -= Time.deltaTime;
                transform.RotateAround(rotationOrigin.position, Vector3.up, Time.deltaTime * -rotateMultiplier);
            }
        }
    }

    public override void DoClickedEvent()
    {
        Debug.Log("Door clicked");
        doorOpen = !doorOpen;

        //need this here or the outline will get stuck 
        //List<Material> editMaterials = new List<Material>();
        //meshRenderer.GetMaterials(editMaterials);

        //editMaterials.RemoveAt(editMaterials.Count - 1);

        //meshRenderer.materials = editMaterials.ToArray();
    }
}
