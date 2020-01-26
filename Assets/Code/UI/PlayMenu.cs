using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour
{

    public GameObject Menu;
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {

            if (Menu.activeSelf == true)
            {
                Unpause();
            }
            else if (Menu.activeSelf == false)
            {
                Menu.SetActive(true);
                GameManager.Instance.Pause();

            }
        }
    }

    public void Unpause()
    {
        Menu.SetActive(false);
        GameManager.Instance.Unpause();
    }

    public void Exit()
    {
        GameManager.Instance.Quite();
    }
}
