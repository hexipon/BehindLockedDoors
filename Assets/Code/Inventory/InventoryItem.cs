using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "ScriptableObjects/InventoryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
    public string itemNameID; // Give each item a unique name so objects can easily check that the player has the correct item
    public Sprite texture; // Texture the item will show when in the inventory UI
    public GameObject prefab; // GameObject the item will instantiate when removed from the inventory and placed back into the world
}
