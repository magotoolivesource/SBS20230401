using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class FallDownDoTween : MonoBehaviour
{

    public float MinX = -8f;
    public float MaxX = 5f;
    public float DurationSec = 3f;
    public Ease Easetype = Ease.Linear;
    public AnimationCurve AniCurve;

    void FallDownAni()
    {
        float randx = Random.Range(MinX, MaxX);
        Vector3 randompos = new Vector3(randx, 5.8f, 0f);
        Vector3 targetpos = randompos;
        targetpos.y = -6.8f;

        transform.position = randompos;

        transform.DOMoveY(-6.8f, DurationSec)
            .SetEase(AniCurve) ;
    }

    void Start()
    {
        FallDownAni();
    }
    
    void Update()
    {
        
    }
}
