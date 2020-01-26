using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossesInput : InputBase
{
    public Camera cam;
    Ray ray;

    public override void Update_(Vector2 inputVector)
    {

        ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.tag == "Crosses")
        {
            Debug.Log("Crosses");
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<InteractableNoughtsCrosses>().AddOTile();
            }
        }
    } 
}
