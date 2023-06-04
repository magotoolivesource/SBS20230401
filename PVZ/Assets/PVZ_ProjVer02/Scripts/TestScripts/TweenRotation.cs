using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenRotation : MonoBehaviour
{

    public Vector3 Rot = new Vector3(0, 0, 360f);
    public float DurationSec = 3f;
    public RotateMode RotMode = RotateMode.FastBeyond360;

    public AnimationCurve CurrCurver;
    void Start()
    {
        //DOVirtual.DelayedCall();
        //DOVirtual.EasedValue(-10, 10, 0.5f);

    }
    
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.T))
        {
            transform.DORotate(Rot, DurationSec, RotMode)
                .SetEase(CurrCurver);

        }

    }
}
