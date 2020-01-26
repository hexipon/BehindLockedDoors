using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChange : MonoBehaviour
{
    // Start is called before the first frame update

    public void ChangeRes(int num)
    {
        switch(num)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(1680, 1050, true);
                break;
            case 2:
                Screen.SetResolution(1080, 720, true);
                break;
        }
    }

}
