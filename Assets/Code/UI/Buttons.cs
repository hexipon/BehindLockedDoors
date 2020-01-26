using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Fx;
    public AudioClip hover;

    public void MainMenu() => GameManager.Instance.MainMenu();
    public void HoverSound() => Fx.PlayOneShot(hover);
    public void Play() => GameManager.Instance.Play();
    public void Instructions() => GameManager.Instance.Instructions();
    public void Exit() => GameManager.Instance.Quite();
    public void Options() => GameManager.Instance.Options();
    public void Unpause() => GameManager.Instance.Unpause();
}
