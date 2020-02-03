using UnityEngine;
using UnityEngine.U2D;

public class RootImpact : MonoBehaviour {
    private ResourceManager resource;
    [SerializeField] SpriteShapeRenderer sprite;

    public void Setup(ResourceManager resource)
    {
        resource.OnWaterChange += OnWaterChanged;
        OnWaterChanged(resource.Water);
    }

    private void OnDisable()
    {
        if (resource != null)
            resource.OnWaterChange -= OnWaterChanged;
    }

    private void OnWaterChanged(float water)
    {
        var color = RootConfig.GetColorByWater(water);
        sprite.color = color;
    }
}