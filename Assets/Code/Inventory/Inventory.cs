using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> Items = new List<InventoryItem>();
    public GameObject inv;
    public List<Image> InvSprites = new List<Image>();
    public static Inventory Instance { get; private set; } = null;

    void Start()
    {
        inv.SetActive(false);
        Instance = this;
    }
    

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I) && Scene1Manager.Instance.state!=Scene1Manager.SceneState.begin)
            inv.SetActive(!(inv.activeSelf));
    }

    //sort
    void SortItems()
    {
        for (int i = 0; i < InvSprites.Count; i++) 
        {
            var img = InvSprites[i].color;
            img.a = 0f;
            InvSprites[i].color = img;
        }
        for (int i = 0; i < Items.Count; i++)
        {
            InvSprites[i].sprite = Items[i].texture;
            var img = InvSprites[i].color;
            img.a = 1f;
            InvSprites[i].color = img;
        }
    }

    public void AddItem(InventoryItem obj)
    {
        Items.Add(obj);
        SortItems();
    }

    public void RemoveItem(string ID)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemNameID == ID)
            {
                Items.Remove(Items[i]);
                break;
            }
        }
        SortItems();
        InvSprites[Items.Count].sprite = null;
    }

    public bool ContainsItem(string ID)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemNameID == ID)
            {
                return true;
            }
        }

        return false;
    }

    public InventoryItem GetItem(string ID)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemNameID == ID)
            {
                return Items[i];
            }
        }

        return null;
    }
}
