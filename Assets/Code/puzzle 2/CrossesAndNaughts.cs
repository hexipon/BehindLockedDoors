using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossesAndNaughts : InteractableBase
{
    private bool playWM = false;
    public GameObject ExitUI;
    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle2;
    }

    public override void DoClickedEvent()
    {
        if (Scene1Manager.Instance.state == Puzzle)
        {
            //triger input/camera change
            Scene1Manager.Instance.CrossesInput();
            ExitUI.SetActive(true);
            if (!playWM)
            {
                Objective.Instance.AssignObjective("Play with me?");
                playWM = true;
            }

            List<Material> editMaterials = new List<Material>();
            meshRenderer.GetMaterials(editMaterials);
            if (editMaterials.Count > 1)
            {

                editMaterials.RemoveAt(editMaterials.Count - 1);

                meshRenderer.materials = editMaterials.ToArray();
            }
        }
    }
}
