using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public static Objective Instance { get; private set; } = null;
    [SerializeField]
    private Text subtitleText = null;
    private float timer = 0.0f;
    private const float fadeTimer = 0.25f;

    private string nextText = "";

    Color col;

    enum State { FadeIn, FadeOut, On, Off };
    State state = State.Off;

    // Start is called before the first frame update
    void Start()
    {
        col = subtitleText.color;
        col.a = 0.0f;
        subtitleText.color = col;
        subtitleText.text = "";

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        switch (state)
        {
            case State.FadeIn:
                if (timer <= 0.0f)
                {
                    col.a = 1.0f;
                    subtitleText.color = col;
                    state = State.On;
                }
                else
                {
                    col.a = 1 - (timer / fadeTimer);
                    subtitleText.color = col;
                }
                break;

            case State.FadeOut:
                if (timer <= 0.0f)
                {
                    col.a = 0.0f;
                    subtitleText.color = col;
                    state = State.Off;
                    timer = 0.0f;

                    subtitleText.text = "";
                }
                else
                {
                    col.a = (timer / fadeTimer);
                    subtitleText.color = col;
                }
                break;

            case State.On:
                // I don't think it needs to do anything here (no timer for the objective)
                break;

            case State.Off:
                if (nextText != "")
                {
                    subtitleText.text = nextText;
                    nextText = "";

                    state = State.FadeIn;
                    timer = fadeTimer;
                }
                break;
        }
    }

    // Call this function
    public void AssignObjective(string text)
    {
        nextText = text;
        timer = fadeTimer;
        state = State.FadeOut;
    }
}
