﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCrosses : MonoBehaviour
{
    public GameObject exitui;
    public void ExitF()
    {
        Scene1Manager.Instance.CharInput();
        exitui.SetActive(false);
    }
}
