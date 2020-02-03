using UnityEngine;
using UnityEngine.UI;

public class SpriteTransition : SurfaceTransition
{
    [SerializeField] Color healthyColor = new Color(90, 134, 41);
    [SerializeField] Color deadColor = new Color(200, 175, 125);

    [SerializeField] float minWater;
    [SerializeField] float maxWater;

    public override void SetWater(float amount)
    {
        GetComponent<Image>().color = Color.Lerp(deadColor, healthyColor, 
            Mathf.Clamp01((amount - minWater) / (maxWater - minWater)));
    }
}