using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeafSway : MonoBehaviour {
    [SerializeField] float swayAmount = 4f;
    [SerializeField] float sweepDuration = 4f;

    private void Start() {
        var minRot = new Vector3(0f, 0f, swayAmount);

        var seq = DOTween.Sequence();
        seq.Append(this.transform.DORotate(minRot, sweepDuration, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine));
        seq.SetLoops(-1, LoopType.Yoyo);
    }
}
