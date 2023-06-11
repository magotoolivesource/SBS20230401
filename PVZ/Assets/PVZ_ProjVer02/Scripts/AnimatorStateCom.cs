using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateCom : MonoBehaviour
{
    protected MineCom m_ParentMineCom = null;

    protected Action<string> m_CallBackAction = null;

    public void InitSetting(Action<string> p_callfn)
    {
        m_CallBackAction = p_callfn;
    }

    public void SetStateType(E_StateType p_str)
    {
        Debug.Log( $"현재상태값 : {p_str}" );
        m_ParentMineCom.CurrentStateType = p_str;


        if( m_CallBackAction != null )
        {
            m_CallBackAction.Invoke(p_str.ToString());
        }
    }

    void Start()
    {
        m_ParentMineCom = GetComponentInParent<MineCom>();


    }
    
    void Update()
    {
        
    }
}
