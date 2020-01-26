using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject controller = null;
    [SerializeField]
    private Light spotlight = null;

    float timer;

    Vector3 originPos;
    Vector3 originRot;

    [SerializeField]
    private Text startText = null;

    // Start is called before the first frame update
    void Start()
    {
        originPos = controller.transform.position;
        originRot = controller.transform.eulerAngles;

        spotlight.intensity = 0;

        startText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 0.8f;

        Vector3 offsetPos = new Vector3(0, Mathf.Cos(timer + 0.8f) * 0.1f, 0);
        controller.transform.position = originPos + offsetPos;

        Vector3 offsetRot = new Vector3(Mathf.Sin(2.0f * timer) * 2.0f, Mathf.Sin(timer) * 6.0f, Mathf.Sin(2.0f * timer) * 2.0f);
        controller.transform.eulerAngles = originRot + offsetRot;

        if (timer < 13.0f)
        {
            if (timer > 3.0f)
            {
                spotlight.intensity = (timer - 3.0f) * 0.06f;
            }
        }
        else if (timer > 20.0f)
        {
            startText.gameObject.SetActive((timer % 1.2f < 0.6f));
        }
    }
}
