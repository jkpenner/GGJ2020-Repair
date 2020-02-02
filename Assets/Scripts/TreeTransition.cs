using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTransition : SurfaceTransition
{
    public GameObject[] levels;
    public float minWater;
    public float maxWater;

    [Range(0.0f, 1.0f)]
    [SerializeField] float test = 0.0f;

    private void OnValidate() {
        SetActiveIndex(Mathf.RoundToInt(test * (levels.Length - 1)));
    }   

    public override void SetWater(float amount)
    {
        float p = Mathf.Clamp01((amount - minWater) / (maxWater - minWater));
        SetActiveIndex(Mathf.RoundToInt(p * (levels.Length - 1)));
    }

    private void SetActiveIndex(int index) {
        for (var i = 0; i < levels.Length; i++)
        {
            bool isActive = i == index;
            if (isActive != levels[i].activeSelf)
            {
                levels[i].SetActive(isActive);
            }
        }
    }
}
