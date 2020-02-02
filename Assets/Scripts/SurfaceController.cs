using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SurfaceTransition : MonoBehaviour
{
    public abstract void SetWater(float amount);
}

public class SurfaceController : MonoBehaviour {
    private ResourceManager resourceManager;

    public float waterAmount;

    [SerializeField] SurfaceTransition[] transitions;

    private void Awake() {
        resourceManager = FindObjectOfType<ResourceManager>();
        SetWaterLevel(resourceManager.Water);
    }

    private void OnEnable() {
        resourceManager.OnWaterChange += SetWaterLevel;
    }

    private void OnDisable() {
        resourceManager.OnWaterChange -= SetWaterLevel;
    }

    private void SetWaterLevel(float amount)
    {
        foreach(var transition in transitions)
        {
            transition.SetWater(amount);
        }
    }
}
