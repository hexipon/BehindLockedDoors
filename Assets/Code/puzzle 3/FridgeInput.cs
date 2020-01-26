using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeInput : InputBase
{
    public Camera cam;
    public GameObject exitUI;
    Ray ray;
    Vector2 offset;
    public GameObject[] magnets;

    public AudioSource radio;
    public AudioSource source;
    
    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public bool cutscene=false;
    private bool ClipPlayed = false;
    private bool ClipPlayed1 = false;
    private bool ClipPlayed2 = false;


    public Material newFrameMat;
    public GameObject Frame;


    void Start()
    {
    }
    public override void Update_(Vector2 inputVector)
    {

        //move numbers on fridge 
        //Debug.Log("fridgeinput");

        ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.Log(Physics.Raycast(ray, out hit));
        //Debug.Log(hit.collider.tag);


        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.tag == "FridgeMag" && !source.isPlaying)
        {
            Debug.Log("moveMag");
            if (Input.GetMouseButton(0))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    offset.x = hit.point.x - hit.collider.transform.position.x;
                    offset.y = hit.point.y - hit.collider.transform.position.y;
                }
                Vector3 newPos = new Vector3(hit.point.x - offset.x, hit.point.y - offset.y, hit.collider.transform.position.z);
                if((newPos.x<0.5f && newPos.x> -0.07f) && (newPos.y < 0.78f && newPos.y > 0.2f))
                    hit.collider.transform.position = newPos;
                if(
                    (
                    (
                    ((magnets[0].transform.position.x > (magnets[1].transform.position.x-magnets[1].transform.localScale.x)) &&
                        (magnets[1].transform.position.x > (magnets[2].transform.position.x - magnets[2].transform.localScale.x)) &&
                        (magnets[2].transform.position.x > (magnets[3].transform.position.x - magnets[3].transform.localScale.x)))
                        )
                        ||
                        (
                    ((magnets[2].transform.position.x > (magnets[1].transform.position.x - magnets[1].transform.localScale.x)) &&
                        (magnets[1].transform.position.x > (magnets[2].transform.position.x - magnets[2].transform.localScale.x)) &&
                        (magnets[0].transform.position.x > (magnets[3].transform.position.x - magnets[3].transform.localScale.x)))
                        )
                        )
                        &&
                        //TODO change to suit actual magnets
                        ((magnets[3].transform.position.y < (magnets[0].transform.position.y + 0.0175)) &&
                        (magnets[1].transform.position.y < (magnets[0].transform.position.y + 0.0175)) &&
                        (magnets[2].transform.position.y < (magnets[0].transform.position.y + 0.0175)))

                        &&
                        ((magnets[3].transform.position.y > (magnets[0].transform.position.y - 0.0175)) &&
                        (magnets[1].transform.position.y > (magnets[0].transform.position.y - 0.0175)) &&
                        (magnets[2].transform.position.y > (magnets[0].transform.position.y - 0.0175)))
                        )
                {
                    Debug.Log("end fridge scene");
                    //blackoutish scene
                    exitUI.SetActive(false);
                    cutscene = true;
                    radio.Stop();
                }
            }
        }


        if(cutscene)
        {
            if(!source.isPlaying && cutscene)
            {
                if(!ClipPlayed)
                {
                    ClipPlayed = true;
                    Subtitles.Instance.AssignDialogue("I never had a chance", clip.length, clip, source);
                }
                else
                {
                    if (!ClipPlayed1)
                    {
                        ClipPlayed1 = true;
                        Subtitles.Instance.AssignDialogue("... I was really looking forward to it", clip1.length, clip1, source);

                    }
                    else
                    {
                        if (!ClipPlayed2)
                        {
                            ClipPlayed2 = true;
                            Subtitles.Instance.AssignDialogue("But we didn’t have enough…", clip2.length, clip2, source);
                        }
                        else
                        {
                            Subtitles.Instance.AssignDialogue("Remeber Steve, it's only for emergencies", clip3.length, clip3, source);
                            Objective.Instance.AssignObjective("You kept it somewhere out of view, junt in case...");
                            Scene1Manager.Instance.state = Scene1Manager.SceneState.puzzle4;
                            Scene1Manager.Instance.CharInput();
                            Frame.GetComponent<MeshRenderer>().material = newFrameMat;
                            cutscene = false;
                        }
                    }

                }
            }

        }
    }


}