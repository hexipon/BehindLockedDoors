using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : InputBase
{
    [SerializeField]
    private float walkSpeed = 2.0f;
    //[SerializeField]
    //private float runSpeed = 4.0f;
    [SerializeField]
    private float gravity = -1.0f;
    [SerializeField]
    private float rotateSpeed = 2.0f;

    private float cameraPitch = 0;

    int solidMask = (1 << 8); // just "Solid"
    int interactMask = (1 << 9) | (1 << 10); // "Interactable" and "Item"

    [SerializeField]
    private GameObject cameraObject = null;
    private CharacterController characterController;
    private Vector3 velocity = Vector3.zero;

    private InteractableBase currentSelected = null;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    public override void Update_(Vector2 inputVector)
    {
            transform.Rotate(transform.up, rotateSpeed * Input.GetAxisRaw("Mouse X"));
            cameraPitch -= rotateSpeed * Input.GetAxisRaw("Mouse Y");
            cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
            cameraObject.transform.localEulerAngles = new Vector3(cameraPitch, 0.0f, 0.0f);
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.4f, -transform.up, out hit, 0.65f, solidMask))
        {
            // Character is on the ground
            velocity.y = 0;

            Vector3 newVel = inputVector.x * transform.right + inputVector.y * transform.forward;
            newVel *= walkSpeed;
            velocity.x = newVel.x;
            velocity.z = newVel.z;
            //velocity = new Vector3(newVel.x, velocity.y + gravity * Time.deltaTime, newVel.z);
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        InteractibleObjectCheck();
    }

    public void InteractibleObjectCheck()
    {

            RaycastHit[] hits = Physics.SphereCastAll(cameraObject.transform.position, 0.2f, cameraObject.transform.forward, 2.0f, interactMask);
            if (hits.Length > 0)
            {
                int bestMatch = 0;
                float bestDistance = 1.0f;
                for (int i = 0; i < hits.Length; i++)
                {
                    float thisDistance = Vector3.Distance(cameraObject.transform.position, hits[i].point);
                    if (thisDistance < bestDistance)
                    {
                        bestDistance = thisDistance;
                        bestMatch = i;
                    }
                }

                InteractableBase interactibleObject = hits[bestMatch].transform.gameObject.GetComponent<InteractableBase>();
                if (interactibleObject != null)
                {
                    //interactibleObject.DoClickedEvent();
                    if (interactibleObject != currentSelected)
                    {
                        if (currentSelected != null)
                        {
                            currentSelected.DoMouseExitEvent();
                        }
                        interactibleObject.DoMouseEnterEvent();
                        currentSelected = interactibleObject;
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        interactibleObject.DoClickedEvent();
                    }
                }
            }
            else
            {
                if (currentSelected != null)
                {
                    currentSelected.DoMouseExitEvent();
                }

                currentSelected = null;
            }

    }

}
