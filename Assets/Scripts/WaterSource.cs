using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(SpriteShapeRenderer))]
public class WaterSource : MonoBehaviour {
    [SerializeField] Color used;


    public void Use()
    {
        GetComponent<SpriteShapeRenderer>().color = used;
    }
}
