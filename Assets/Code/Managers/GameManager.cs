using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    enum GameState
    {
        mainMenu,
        play,
        pause,
        unpause,
        instructions,
        options,
        gameOver
    }
    private GameState gameState;
    private int VolumeLevel=100;
    private float mouseSensitivity=1f;
    public AudioMixer mixer;

    public static GameManager Instance { get; private set; } = null;
    void Start()
    {
        if (Instance != null) //only have one SceneManager
            Destroy(gameObject);
        else
        {
            Screen.SetResolution(1680, 1050, true); //this is the default because the monitors we're using are this weird resolution 
            Instance = this;
            ChangeState(GameState.mainMenu);
            DontDestroyOnLoad(gameObject);
        }
    }

    void ChangeState(GameState newState)
    {
        switch (newState)
        {
            case GameState.mainMenu:
                //go to main menu
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = (true);
                SceneManager.LoadScene(0);
                gameState = GameState.mainMenu;
                break;
            case GameState.options:
                //go to options
                gameState = GameState.options;
                SceneManager.LoadScene(1);
                break;
            case GameState.instructions:
                //go to instructions
                gameState = GameState.instructions;
                SceneManager.LoadScene(2);
                break;
            case GameState.play:
                //go to playing
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                gameState = GameState.play;
                SceneManager.LoadScene(3);
                break;
            case GameState.gameOver:
                //go to game over
                gameState = GameState.gameOver;
                break;
            case GameState.unpause:
                //go to unpause
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                gameState = GameState.play;
                break;
            case GameState.pause:
                //go to pause
                gameState = GameState.pause;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
            default:
                break;
        }
    }


    //actualy state change functions
    public void MainMenu() => ChangeState(GameState.mainMenu);
    public void Options() => ChangeState(GameState.options);
    public void Instructions() => ChangeState(GameState.instructions);
    public void Pause() => ChangeState(GameState.pause);
    public void Unpause() => ChangeState(GameState.unpause);
    public bool IsGamePlaying() => (gameState == GameState.play);
    public void Play() => ChangeState(GameState.play);
    public void GameOver() => ChangeState(GameState.gameOver);

    public void Quite() //exit game both in standalone and editor mode
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public void SetSensitivity(float val) => mouseSensitivity = val; //setting character mous emovement sensitivity
    public float GetSensitivity() => mouseSensitivity;

    public void SetVolume(int val)
    {
        VolumeLevel = val;
        mixer.SetFloat("Master", val-80);
    }

    public int GetVolume() => VolumeLevel;

    public float GetNormalizedVolume() => (float)VolumeLevel / 100;
}
