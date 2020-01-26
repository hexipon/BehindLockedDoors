using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamRotate : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
