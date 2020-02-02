using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour {
    [SerializeField] float moveSpeed = 1;
    [SerializeField] Vector2 xRange;

    private void Update() {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        float min = xRange.x;
        float max = xRange.y;

        if (transform.position.x > max) {
            transform.position = new Vector2(min, transform.position.y);
        }
        if (transform.position.y < min) {
            transform.position = new Vector3(max, transform.position.y);
        }
    }    
}
