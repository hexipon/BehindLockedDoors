using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoughtsCrossesTile : InteractableBase
{
    public InventoryItem inventoryItem;

    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle2;
    }

    public override void DoClickedEvent()
    {
        Debug.Log(Scene1Manager.Instance.state == Puzzle);
        if (Scene1Manager.Instance.state == Puzzle)
        {
            Debug.Log("Adding item: " + inventoryItem.itemNameID);

            // Add inventoryItem to the player's inventory
            // Not implemented yet!

            Inventory.Instance.AddItem(inventoryItem);

            // Remove this object from the scene

            Destroy(gameObject);
        }
    }
}
