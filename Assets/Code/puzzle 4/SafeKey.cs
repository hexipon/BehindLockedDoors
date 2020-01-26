using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeKey : InteractableBase
{
    public InventoryItem inventoryItem;
    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle4;
    }

    public override void DoClickedEvent()
    {
        Debug.Log(Scene1Manager.Instance.state == Puzzle);
        if (Scene1Manager.Instance.state == Puzzle)
        {
            Debug.Log("Adding item: " + inventoryItem.itemNameID);

            Objective.Instance.AssignObjective("Find the safe");

            Inventory.Instance.AddItem(inventoryItem);

            // Remove this object from the scene

            Destroy(gameObject);
        }
    }
}
