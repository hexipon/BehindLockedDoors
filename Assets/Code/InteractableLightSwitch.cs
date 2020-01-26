using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLightSwitch : InteractableBase
{
    [SerializeField]
    private GameObject lightObject = null;
    private bool lightOn;

    // Start is called before the first frame update
    void Awake()
    {
        lightOn = lightObject.activeInHierarchy;
    }

    public override void DoClickedEvent()
    {
        lightOn = !lightOn;
        lightObject.SetActive(lightOn);
    }
}
