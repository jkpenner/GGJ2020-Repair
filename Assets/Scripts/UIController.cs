using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] CanvasGroup sproutGroup;
    [SerializeField] Text sproutText;
    [SerializeField] CanvasGroup cancelGroup;
    [SerializeField] Text cancelText;


    private GameManager gameManager;
    private ResourceManager resourceManager;

    private void Awake()
    {
        this.gameManager = GameManager.GetInstance();
        this.resourceManager = FindObjectOfType<ResourceManager>();
        this.OnStatChange(this.gameManager.ActiveState);
    }

    private void OnEnable()
    {
        this.gameManager.OnGameStateChange += OnStatChange;
        this.resourceManager.OnWaterDrained += OnWaterDrained;
    }

    private void OnDisable()
    {
        this.gameManager.OnGameStateChange -= OnStatChange;
        this.resourceManager.OnWaterDrained -= OnWaterDrained;
    }

    private void OnWaterDrained()
    {
        if (this.gameManager.ActiveState == GameState.Retreat)
        {
            sproutGroup.alpha = this.resourceManager.IsWaterDrained ? 0f : 1f;
        }
    }

    private void OnStatChange(GameState state)
    {
        switch(state) {
            case GameState.Retreat:
                sproutGroup.alpha = this.resourceManager.IsWaterDrained ? 0f : 1f;
                sproutText.text = "Start Sprout";
                cancelGroup.alpha = 0;
            break;
            case GameState.Aim:
                sproutGroup.alpha = 1;
                sproutText.text = "Start Sprout";
                cancelGroup.alpha = 1;
                cancelText.text = "Cancel";
            break;
            default:
                sproutGroup.alpha = 0;
                cancelGroup.alpha = 0;
            break;
        }
    }
}