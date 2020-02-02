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

    [SerializeField] RootController prefab;
    [SerializeField] Transform spawnPosition;

    public RootController Player { get; private set; }

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

        if (prefab.gameObject.activeSelf)
            prefab.gameObject.SetActive(false);

        this.Player = Instantiate(prefab);
        this.Player.transform.position = spawnPosition.position;
        this.Player.gameObject.SetActive(true);

        startSequence.gameObject.SetActive(false);
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
        Destroy(this.Player.gameObject);
        this.exitSequence.gameObject.SetActive(true);
        this.exitSequence.stopped += OnExitStopped;
        this.exitSequence.Play();
    }

    private void OnExitStopped(PlayableDirector obj)
    {
        SceneManager.LoadScene("MainMenu");
    }
}