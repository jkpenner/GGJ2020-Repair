using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour {
    public void SetPlayer(Transform target) 
    {
        var cam = GetComponent<CinemachineVirtualCamera>();
        cam.Follow = target;
    }
}
