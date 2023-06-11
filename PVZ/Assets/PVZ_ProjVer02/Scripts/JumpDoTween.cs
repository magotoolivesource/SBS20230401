using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class JumpDoTween : MonoBehaviour
{

    public float DurationSec = 1f;
    public float MinRange = 0.5f;
    public float RandomRange = 2f;
    public Ease Easetype = Ease.Linear;
    //public AnimationCurve 


    protected Vector3 m_RandTargetPos = new Vector3();

    protected void JumpAni()
    {
        Vector3 m_RandTargetPos = transform.position;
        Vector3 range = (Random.insideUnitCircle * RandomRange);

        if(range.magnitude < MinRange)
        {
            range = range.normalized * MinRange;
        }

        m_RandTargetPos = (m_RandTargetPos + range);

        float jumppow = 0f;
        float comparey = (m_RandTargetPos.y - transform.position.y);
        if (comparey >= 0f)
        {
            jumppow = (comparey * 0.5f) + 1f;
        }
        else
        {
            jumppow = (comparey * 0.1f) + 1f;
        }

        float randomsec = Random.Range(-0.2f, 0.2f) + DurationSec;
        transform.DOJump(m_RandTargetPos, jumppow, 1, randomsec)
            .SetEase(Easetype);


        Debug.DrawLine(transform.position, m_RandTargetPos, Color.red, randomsec + 0.2f);

    }

    void Start()
    {
        JumpAni();
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube()
    }




    //void Update()
    //{
    //}

}
