using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNoughtsCrosses : InteractableBase
{
    public GameObject slotObject = null;
    [SerializeField]
    int tileIndex = 0;

    [SerializeField]
    private string noughtID = "NoughtTile";

    // Start is called before the first frame update
    void Start()
    {
        Puzzle = Scene1Manager.SceneState.puzzle2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoClickedEvent()
    {
        //nah
    }

    public void AddOTile()
    {
        if (Scene1Manager.Instance.state == Puzzle && slotObject == null)
        {
            if (NoughtsCrossesController.Instance.PlayerTurn())
            {
                if (Inventory.Instance.ContainsItem(noughtID))
                {
                    slotObject = Instantiate(Inventory.Instance.GetItem(noughtID).prefab);
                    slotObject.transform.position = transform.position;
                    NoughtsCrossesController.Instance.SetTile(tileIndex, 'O');

                    Inventory.Instance.RemoveItem(noughtID);
                }
            }
        }
    }

    public void AddCrossTile()
    {
        if (Scene1Manager.Instance.state == Puzzle && slotObject == null)
        {
            if (!NoughtsCrossesController.Instance.PlayerTurn())
            {
                slotObject = Instantiate(NoughtsCrossesController.GetCrossPrefab());
                slotObject.transform.position = transform.position;
                NoughtsCrossesController.Instance.SetTile(tileIndex, 'X');
            }
        }
    }

    public void Restart()
    {
        // remove slotobject

        Destroy(slotObject);
        slotObject = null;
    }
}
