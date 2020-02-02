using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(SpriteShapeRenderer))]
public class GrassTransition : SurfaceTransition {
    [SerializeField] Color healthyColor = new Color(90, 134, 41);
    [SerializeField] Color deadColor = new Color(200, 175, 125);

    [Range(0f, 1f)]
    [SerializeField] float value = 0.0f;

    [SerializeField] float minWater;
    [SerializeField] float maxWater;

    private void OnValidate() {
        GetComponent<SpriteShapeRenderer>().color = Color.Lerp(deadColor, healthyColor, value);
    }

    public override void SetWater(float amount)
    {
        GetComponent<SpriteShapeRenderer>().color = Color.Lerp(deadColor, healthyColor, 
            Mathf.Clamp01((amount - minWater) / (maxWater - minWater)));
    }
}