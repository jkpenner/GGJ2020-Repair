using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class UIWater : MonoBehaviour
{
    private GameManager gameManager;
    private ResourceManager resource;
    private CanvasGroup group;

    [SerializeField] Text text;

    [SerializeField] RectTransform fillbar;

    private void Awake()
    {
        this.resource = FindObjectOfType<ResourceManager>();
        this.group = GetComponent<CanvasGroup>();

        this.gameManager = GameManager.GetInstance();
        this.OnStateChange(this.gameManager.ActiveState);
    }

    private void OnEnable()
    {
        this.gameManager.OnGameStateChange += OnStateChange;
        this.resource.OnWaterChange += OnWaterChange;
        this.resource.OnWaterDrained += OnWaterDrained;
    }

    private void OnDisable()
    {
        this.resource.OnWaterChange -= OnWaterChange;
        this.resource.OnWaterDrained -= OnWaterDrained;
        this.gameManager.OnGameStateChange -= OnStateChange;
    }

    private void OnStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.Intro:
            case GameState.Exit:
            case GameState.WinRetreat:
                this.group.alpha = 0f;
                break;
            default:
                this.group.alpha = 1f;
                break;
        }
    }

    private void OnWaterChange(float water)
    {
        text.text = string.Format("Water: {0:0}", ((int)water).ToString().PadLeft(5));
        fillbar.localScale = new Vector3(
            Mathf.Clamp01(water / 160), 1f, 1f
        );
    }

    private void OnWaterDrained()
    {
        text.text = "Water: Drained!";
        fillbar.localScale = new Vector3(0f, 1f, 1f);
    }
}
