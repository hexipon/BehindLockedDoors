using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lada : MonoBehaviour
{
    public void Exit()
    {
        GameManager.Instance.Quite();
    }
}
