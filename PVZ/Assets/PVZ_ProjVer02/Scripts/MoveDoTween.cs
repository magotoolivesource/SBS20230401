using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveDoTween : MonoBehaviour
{

    public Ease CurrentEase = Ease.InBack;
    public void Init(Vector3 p_stpos, Vector3 p_targetpos, float p_durationsec)
    {
        transform.position = p_stpos;
        this.transform.DOMove(p_targetpos, p_durationsec)
            .SetEase(CurrentEase)
            .OnComplete( OnCompleteFN ) ;


    }

    protected void OnCompleteFN()
    {
        //GameObject.Destroy(this);
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
