using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class FallDownDoTween : MonoBehaviour
{

    public float MinX = -8f;
    public float MaxX = 5f;
    public float MinY = 2.8f;
    public float MaxY = -4.11f;

    //public Bounds RectBound;
    public Rect RangeSize = new Rect();

    public float DurationSec = 3f;
    public Ease Easetype = Ease.Linear;
    public AnimationCurve AniCurve;

    

    public void InitSetting(Rect p_rect)
    {
        RangeSize = p_rect;
        MinX = RangeSize.xMin;
        MaxX = RangeSize.xMax;

        MinY = RangeSize.yMin;
        MaxY = RangeSize.yMax;
    }

    void FallDownAni()
    {
        float randx = Random.Range(RangeSize.xMin, RangeSize.xMax);
        Vector3 randompos = new Vector3(randx, 5.8f, 0f);
        Vector3 targetpos = randompos;
        //targetpos.y = -6.8f;

        transform.position = randompos;

        float randomy = Random.Range(RangeSize.yMin, RangeSize.yMax);
        transform.DOMoveY(randomy, DurationSec)
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
