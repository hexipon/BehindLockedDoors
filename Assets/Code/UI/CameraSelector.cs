using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSelector : MonoBehaviour
{
    [SerializeField]
    Buttons buttons = null;

    private LayerMask interactable = (1 << 9);

    private Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, 100.0f, interactable))
            {
                buttons.Play();
            }
        }
    }
}
