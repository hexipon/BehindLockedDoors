using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChange : MonoBehaviour
{


    public Text text;
    public Slider slider;
    public void Start() => slider.value = GameManager.Instance.GetVolume();
    public void ChangeVolSpeed(float val)
    {
        text.text = val.ToString() + "%";
        GameManager.Instance.SetVolume((int)val);
    }

}
