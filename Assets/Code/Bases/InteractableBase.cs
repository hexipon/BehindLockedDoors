using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class InteractableBase : MonoBehaviour
{
    [SerializeField]
    private Material outlineMaterial = null;

    protected MeshRenderer meshRenderer;
    protected Scene1Manager.SceneState Puzzle; //change this depening on interactable item

    protected virtual Scene1Manager.SceneState Puz
    {
        get { return Puzzle; }
        set { Puzzle = value; }
    }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public virtual void DoClickedEvent()
    {
        Debug.Log("Interactable object was clicked");
    }

    public void DoMouseEnterEvent()
    {
        /*Material[] editMaterials = meshRenderer.materials; // This copies the MeshRenderer's array - it's not a reference
        Material[] newMaterials = new Material[editMaterials.Length + 1];

        for (int i = 0; i < editMaterials.Length; i++)
        {
            newMaterials[i] = editMaterials[i];
        }
        newMaterials[newMaterials.Length - 1] = outlineMaterial;

        meshRenderer.materials = newMaterials;*/

        Debug.Log(Scene1Manager.Instance.state + ":" + (Scene1Manager.Instance.state == Puzzle));
        if (Scene1Manager.Instance.state == Puzzle)
        {
            List<Material> editMaterials = new List<Material>();
            meshRenderer.GetMaterials(editMaterials);

            editMaterials.Add(outlineMaterial);

            meshRenderer.materials = editMaterials.ToArray();
        }
    }

    public void DoMouseExitEvent()
    {
        /*Material[] editMaterials = meshRenderer.materials; // This copies the MeshRenderer's array - it's not a reference
        Material[] newMaterials = new Material[editMaterials.Length - 1];

        for (int i = 0; i < newMaterials.Length; i++)
        {
            newMaterials[i] = editMaterials[i];
        }

        meshRenderer.materials = newMaterials;*/
            List<Material> editMaterials = new List<Material>();
                meshRenderer.GetMaterials(editMaterials);
            if (editMaterials.Count > 1)
            {

                editMaterials.RemoveAt(editMaterials.Count - 1);

                meshRenderer.materials = editMaterials.ToArray();
            }
    }
}
