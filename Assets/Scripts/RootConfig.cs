using UnityEngine;

public static class RootConfig
{
    public const float MinWater = 0f;
    public const float MaxWater = 150f;

    public static Color GetColorByWater(float water)
    {
        return Color.Lerp(GetDyingColor(), GetHealthyColor(), 
            Mathf.Clamp01((water - MinWater) / (MaxWater - MinWater)));
    }

    public static Color GetHealthyColor()
    {
        return new Color(70f/255f, 212f/255f, 0);
    }

    public static Color GetDyingColor()
    {
        return new Color(200f/255f, 175f/255f, 125f/255f);
    }
}