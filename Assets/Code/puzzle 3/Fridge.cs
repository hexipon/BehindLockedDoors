using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : InteractableBase
{
    public GameObject exitui;
    // Start is called before the first frame update
    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle3;
    }
    
    public override void DoClickedEvent()
    {
        if(Scene1Manager.Instance.state == Puzzle)
        {
            //triger input/camera change
            Scene1Manager.Instance.FridgeInput();
            exitui.SetActive(true);
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