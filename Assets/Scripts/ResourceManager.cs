using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] float water = 100f;
    [SerializeField] float waterDrainRate = 2.0f;
    [SerializeField] float waterGainPerCollection = 100f;

    public float Water { get { return water; } }
    public bool IsWaterDrained { get; private set; }

    public delegate void WaterEvent(float water);
    public event WaterEvent OnWaterChange;
    public event Action OnWaterDrained;

    private void Awake() {
        this.gameManager = GameManager.GetInstance();
    }

    public void Update()
    {
        if (this.gameManager.ActiveState == GameState.WinRetreat)
            return;


        if (!this.IsWaterDrained && this.gameManager.ActiveState == GameState.Active)
        {
            this.water -= this.waterDrainRate * Time.deltaTime;
            this.OnWaterChange?.Invoke(this.water);
            if (this.water <= 0f)
            {
                this.IsWaterDrained = true;
                this.water = 0f;
                this.OnWaterDrained?.Invoke();
            }
        }
    }

    public void HitWaterResource()
    {
        if (!this.IsWaterDrained)
        {
            this.water += this.waterGainPerCollection;
            this.OnWaterChange?.Invoke(this.water);
        }
    }
}