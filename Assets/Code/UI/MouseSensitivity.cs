using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Slider slider;
    void Start() => slider.value = GameManager.Instance.GetSensitivity() * 10;

    public void ChangeMouseSpeed(float val)
    {
        float sense = val / 10f;
        text.text = sense.ToString();
        Vector2 sensitivity = new Vector2(sense, sense);
        Vector2 mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X") * sensitivity.x, Input.GetAxisRaw("Mouse Y") * sensitivity.y);
        GameManager.Instance.SetSensitivity(sense);
    }
}
