using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Scene1Manager : MonoBehaviour
{
    public GameObject startCam;
    public GameObject playerCam;
    public AudioSource source;
    public AudioClip clip1; //player clip
    public AudioClip clip2; //narrator clip

    public GameObject BlankUi;

    public static Scene1Manager Instance { get; private set; } = null;
    public enum SceneState
    {
        narrator,
        begin,
        puzzle1,
        puzzle2,
        puzzle3,
        puzzle4,
        endGame
    }

    public SceneState state;
    public GameObject Inp; //where input goes to
    public GameObject FridgeCam;
    public GameObject Char;
    public GameObject CrossesCam;
    public GameObject phone;

    void Start()
    {
        BlankUi.SetActive(true);
        Instance = this;
        state = SceneState.narrator;
        phone.GetComponent<Landline>().PlayRing();
        Subtitles.Instance.AssignDialogue("Holding onto small fragments of hope, waiting for what you \ndeserve, it holds you back. \n Looking at a small part of the piece instead of the whole picture leads to \nnarrow mindedness: Complacency.\nYou are the controller…", clip2.length, clip2, source);
    }


    void Update()
    {
        if(!source.isPlaying && BlankUi.GetComponent<Image>().color.a>0 && state== SceneState.narrator)
        {
            Image image = BlankUi.GetComponent<Image>();
            Color trans = image.color;
            trans.a -= 0.01f;
            image.color = trans;
        }
        if (!source.isPlaying && BlankUi.GetComponent<Image>().color.a <= 0 && state == SceneState.narrator)
        {
        BlankUi.SetActive(false);
        state = SceneState.begin;
        }
        if (state != SceneState.narrator)
        {
            Vector2 inputVector = Vector2.zero;
            //let video play, then move camera to player camera position, then swap camera
            if (startCam.transform.position == playerCam.transform.position && startCam.activeSelf)
            {
                Inp = Char;
                playerCam.SetActive(true);
                startCam.SetActive(false);
                state = SceneState.puzzle1;
                Subtitles.Instance.AssignDialogue("Wh-what? Oh (yawns,) I must’ve fallen asleep… I can’t see a thing except for the TV, best turn on the lamp.", clip1.length, clip1, source);
            }
            else if (startCam.activeSelf)
            {
                startCam.transform.position = Vector3.MoveTowards(startCam.transform.position, playerCam.transform.position, 0.01f);
            }
            if (GameManager.Instance.IsGamePlaying())
            {
                inputVector.x = Input.GetAxis("Horizontal");
                inputVector.y = Input.GetAxis("Vertical");
                //send 
                if (state != SceneState.begin && state != SceneState.endGame)
                {
                    Inp.GetComponent<InputBase>().Update_(inputVector);
                }
            }
        }
    }

    public void FridgeInput()
    {
        Inp = FridgeCam;
        FridgeCam.SetActive(true);
        playerCam.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = (true);
    }

    public void CharInput()
    {
        Inp = Char;
        playerCam.SetActive(true);
        FridgeCam.SetActive(false);
        CrossesCam.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void CrossesInput()
    {
        Inp = CrossesCam;
        CrossesCam.SetActive(true);
        playerCam.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = (true);

    }


}
