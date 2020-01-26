using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractableBase
{
    public GameObject LightBulb;
    [SerializeField]
    private string ID = "Bulb";
    private bool lightOn = false;

    public AudioClip clip;
    public AudioClip clip2;
    public AudioSource source;

    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle1;
    }

    public override void DoClickedEvent()
    {
        if (Scene1Manager.Instance.state == Puzzle)
        {
            if (!Inventory.Instance.ContainsItem(ID) && !lightOn /*&&!soundDebounce*/)
            {
                source.Stop();
                Subtitles.Instance.AssignDialogue("Dammit, bulb must be dead. I’m sure I kept a spare close by…", clip.length, clip, source);
                Objective.Instance.AssignObjective("Find the spare bulb");
            }
            else
            {
                lightOn = true;
                source.Stop();
                Subtitles.Instance.AssignDialogue("What was I even doing earlier anyway? I- I can’t remember.", clip2.length, clip2, source);
                Objective.Instance.AssignObjective("Try and jog your memory by looking around");
                LightBulb.SetActive(true);
                Inventory.Instance.RemoveItem(ID);
                Scene1Manager.Instance.state = Scene1Manager.SceneState.puzzle2;

                List<Material> editMaterials = new List<Material>();
                meshRenderer.GetMaterials(editMaterials);

                editMaterials.RemoveAt(editMaterials.Count - 1);

                meshRenderer.materials = editMaterials.ToArray();
            }
        }
    }
}
