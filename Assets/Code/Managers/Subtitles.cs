using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{

    public static Subtitles Instance { get; private set; } = null;
    [SerializeField]
    private Text subtitleText = null;
    private float timer = 0.0f;
    private const float fadeTimer = 0.25f;

    private float nextTimer = 0.0f;
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

                    timer = nextTimer;
                    nextTimer = 0.0f;
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
                if (timer <= 0.0f)
                {
                    state = State.FadeOut;
                    timer = fadeTimer;
                }
                break;

            case State.Off:
                if (nextTimer >= 0.0f && nextText != "")
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
    public void AssignDialogue(string text, float time, AudioClip dialogue, AudioSource source)
    {
            source.PlayOneShot(dialogue, GameManager.Instance.GetNormalizedVolume());
            nextText = text;
            nextTimer = time;

            state = State.FadeOut;
            timer = fadeTimer;
    }
}
