using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMove : MonoBehaviour
{
    public Ease m_CurrentEase = Ease.Linear;


    public Transform m_Target = null;
    public float m_DrutaionSec = 1f;

    void Start()
    {
        
    }


    public Tween MoveTween = null;
    void _Editor_Move()
    {
        //MoveTween.Play();
        //MoveTween.Pause();
        //MoveTween.Kill();

        MoveTween = transform.DOMove(m_Target.position, m_DrutaionSec)
            .SetEase( m_CurrentEase )
            .OnComplete( CompleteFN )
            .SetLoops(-1, LoopType.Yoyo)
            .OnStepComplete(StepCompleteFN );

    }

    void _Editor_Move2()
    {
        Vector3 initpos = new Vector3(-6, 2, 0);
        transform.position = initpos;


        SpriteRenderer render = GetComponent<SpriteRenderer>();


        Sequence seu = DOTween.Sequence();

        seu.Append( transform.DOMove(new Vector3(4, 2, 0), 2f).OnComplete(StepCompleteFN) );
        seu.AppendCallback(StepCompleteFN);
        seu.AppendInterval(1.4f);
        seu.Append( transform.DOMove(new Vector3(4, -2, 0), 2f) );
        seu.Append( transform.DOMove(new Vector3(-4, -2, 0), 2f) );

        seu.OnComplete(CompleteFN2);

        seu.Insert(1f, render.DOFade(0f, 1f).SetLoops(2, LoopType.Yoyo) );
        seu.Insert(0.4f, transform.DORotate(new Vector3(0f, 0f, 720f), 3, RotateMode.WorldAxisAdd) );

        //seu.Play();
        //seu.Pause();


        //transform.DOMove( new Vector3(4, 2, 0) , 2f)
        //    .OnComplete( () => {
        //        transform.DOMove(new Vector3(4, -2, 0), 2f)
        //        .OnComplete( () => {
        //            transform.DOMove(new Vector3(-4, -2, 0), 2f);
        //        }
        //        );
        //    }
        //    );
    }

    void CompleteFN2()
    {
        Debug.Log("시퀀스 함수 호출");
    }

    void StepCompleteFN()
    {
        Debug.Log("함수 호출22");
    }
    void CompleteFN()
    {
        Debug.Log("함수 호출");
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.T) )
        {
            _Editor_Move();
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            _Editor_Move2();
        }
        
    }
}
