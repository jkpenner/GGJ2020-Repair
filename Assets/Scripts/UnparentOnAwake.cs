using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentOnAwake : MonoBehaviour {
    private void Awake() {
        this.transform.SetParent(null);
    }    
}
