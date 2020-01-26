using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterExit : MonoBehaviour
{
    public GameObject UI;
public void Exit()
    {
        UI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
