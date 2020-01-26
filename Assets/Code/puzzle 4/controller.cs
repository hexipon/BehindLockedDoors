using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : InteractableBase
{
    public override void DoClickedEvent()
    {
        Scene1Manager.Instance.state = Scene1Manager.SceneState.endGame;
        //cut scene to galaga won
        //show end menu
    }
}
