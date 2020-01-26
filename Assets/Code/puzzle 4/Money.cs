using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : InteractableBase
{
    public GameObject EndUI;
    public override void DoClickedEvent()
    {
        Scene1Manager.Instance.state = Scene1Manager.SceneState.endGame;
        EndUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = (true);
        //GameManager.Instance.Play();
    }
}
