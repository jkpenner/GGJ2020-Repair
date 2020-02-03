using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] CanvasGroup[] sproutGroup;
    [SerializeField] Text[] sproutText;
    [SerializeField] CanvasGroup[] cancelGroup;
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
            foreach(var group in sproutGroup)
                group.alpha = this.resourceManager.IsWaterDrained ? 0f : 1f;
        }
    }

    private void OnStatChange(GameState state)
    {
        switch (state)
        {
            case GameState.Retreat:
                foreach (var group in sproutGroup)
                    group.alpha = this.resourceManager.IsWaterDrained ? 0f : 1f;
                foreach (var text in sproutText)
                    text.text = "Start Sprout";
                foreach (var group in cancelGroup)
                    group.alpha = 0;
                break;
            case GameState.Aim:
                foreach (var group in sproutGroup)
                    group.alpha = 1;
                foreach (var text in sproutText)
                    text.text = "Sprout";
                foreach (var group in cancelGroup)
                    group.alpha = 1;
                cancelText.text = "Cancel";
                break;
            default:
                foreach (var group in sproutGroup)
                    group.alpha = 0;
                foreach (var group in cancelGroup)
                    group.alpha = 0;
                break;
        }
    }
}