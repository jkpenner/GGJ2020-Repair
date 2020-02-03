using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum GameState
{
    Intro, Active, Dead, Retreat, WinRetreat, Aim, Exit
}

public class GameManager : MonoBehaviour
{
    public static GameManager GetInstance()
    {
        return FindObjectOfType<GameManager>();
    }

    #region  Game States
    public delegate void GameStateEvent(GameState state);
    public event GameStateEvent OnGameStateChange;
    public GameState ActiveState { get; private set; }
    #endregion

    public PlayableDirector startSequence;
    public PlayableDirector exitSequence;

    [SerializeField] RootController rootController;
    [SerializeField] Transform spawnPosition;
    [SerializeField] PlayerCamera playerCamera;

    public RootController Player { get; private set; }

    private void Awake() {
        rootController.gameObject.SetActive(false);    
    }

    private void Start()
    {
        SetState(GameState.Intro);
        startSequence.stopped += OnIntroStopped;
        startSequence.Play();
        exitSequence.gameObject.SetActive(false);
    }

    private void OnIntroStopped(PlayableDirector obj)
    {
        startSequence.stopped -= OnIntroStopped;
        Debug.Log("Intro Stopped");

        if (rootController != null)
            rootController.gameObject.SetActive(true);
        this.Player = rootController;

        startSequence.gameObject.SetActive(false);
        SetState(GameState.Active);
    }

    public void SetState(GameState state)
    {
        if (this.ActiveState != state)
        {
            this.ActiveState = state;
            this.OnGameStateChange?.Invoke(state);

            if (this.ActiveState == GameState.Exit)
            {
                this.OnGameExit();   
            }
        }
    }

    private void OnGameExit()
    {
        this.Player.gameObject.SetActive(false);
        this.exitSequence.gameObject.SetActive(true);
        this.exitSequence.stopped += OnExitStopped;
        this.exitSequence.Play();
    }

    private void OnExitStopped(PlayableDirector obj)
    {
        SceneManager.LoadScene("MainMenu");
    }
}