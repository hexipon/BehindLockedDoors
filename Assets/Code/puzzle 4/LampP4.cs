using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampP4 : InteractableBase
{
    public GameObject LightBulb;
    [SerializeField]

    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle4;
    }

    public override void DoClickedEvent()
    {
        LightBulb.SetActive(true);

        List<Material> editMaterials = new List<Material>();
        meshRenderer.GetMaterials(editMaterials);
        if (editMaterials.Count > 1)
        {

            editMaterials.RemoveAt(editMaterials.Count - 1);

            meshRenderer.materials = editMaterials.ToArray();
        }
    }
}
