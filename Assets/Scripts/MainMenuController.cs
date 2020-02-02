using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem;

public class MainMenuController : MonoBehaviour {
    public PlayableDirector intro;
    public PlayableDirector outro;
    private PlayerInput input;

    public bool CanStartGame { get; private set; }

    [SerializeField] CanvasGroup canvasGroup;

    private void Awake() {
        intro.gameObject.SetActive(false);
        outro.gameObject.SetActive(false);

        this.canvasGroup.alpha = 0f;
        this.CanStartGame = false;

        input = new PlayerInput();
        input.MainMenu.Start.performed += (ctx) => {
            if (this.CanStartGame) 
            {
                StartOutro();
            }
        };
        input.MainMenu.Quit.performed += (ctx) => {
            Application.Quit();
        };
        
        

        StartIntro();   
    }

    private void OnEnable() {
        input.Enable();
    }
    
    private void OnDisable() {
        input.Disable();
    }

    private void StartIntro()
    {
        this.intro.gameObject.SetActive(true);
        this.intro.stopped += OnIntroStopped;
        this.intro.Play();
    }

    private void OnIntroStopped(PlayableDirector director)
    {
        this.intro.stopped -= OnIntroStopped;
        this.intro.gameObject.SetActive(false);

        canvasGroup.DOFade(1f, 1f).OnComplete(() => {
            this.CanStartGame = true;
        });
    }

    private void StartOutro()
    {
        this.CanStartGame = false;
        canvasGroup.DOFade(0f, 1f).OnComplete(() => {
            this.outro.gameObject.SetActive(true);
            this.outro.stopped += OnOutroStopped;
            this.outro.Play();
        });
    }

    private void OnOutroStopped(PlayableDirector director)
    {
        this.outro.stopped -= OnIntroStopped;
        this.outro.gameObject.SetActive(false);

        SceneManager.LoadScene("GamePlay");
    }
}
