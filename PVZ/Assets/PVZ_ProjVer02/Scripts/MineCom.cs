using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_StateType
{
    Ready,
    Idle,
    Attack1,
    Damage,
    Die,
    Boom,

    Max
}


public class MineCom : MonoBehaviour
{
    public E_StateType CurrentStateType = E_StateType.Max;
    public Animator m_LinkAnimator = null;

    public GameObject TargetObject = null;

    public void SetStateType( E_StateType p_statetype )
    {
        Debug.Log($"다이렉트 상태 : {p_statetype}");
        CurrentStateType = p_statetype;

        CheckBoom();
    }

    protected void CheckBoom()
    {
        if (CurrentStateType == E_StateType.Ready
            && TargetObject != null)
        {
            m_LinkAnimator.SetBool("Boom", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( !collision.tag.Contains("Enemy") )
        {
            return;
        }

        TargetObject = collision.gameObject;

        CheckBoom();
    }


    protected void SetAnimatorEvent(string p_val)
    {
        //Debug.Log( $"콜백함수 호출 : {p_val}" );
    }

    void Start()
    {
        GetComponentInChildren<AnimatorStateCom>().InitSetting( SetAnimatorEvent );


        AniStateCom[] anistatecomarr = m_LinkAnimator.GetBehaviours<AniStateCom>();
        foreach (var item in anistatecomarr)
        {
            item.LinkMineCom = this;
        }


    }
    
    void Update()
    {

        //m_LinkAnimator.GetCurrentAnimatorStateInfo(0).IsName("");


    }
}
