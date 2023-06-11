using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DelayEventCom : MonoBehaviour
{
    [System.Serializable]
    public class DelayEvent : UnityEvent { }
    public DelayEvent onDelayCallFN = new DelayEvent();

    public float DelaySec = 1f;


    //public bool ISRepeat = false;
    [Tooltip("0이하면 무한히 실행함")]
    public int RepeatCount = 1; // 무한으로 진행 


    [Header("[확인용]")]
    [SerializeField]
    protected float m_CurrentSec = 0f;
    protected int m_CurrentRepeatCount = 0;

    void Start()
    {
        ResetCurrentSec();
        SetRepeatCount(RepeatCount);
    }
    
    public void SetRepeatCount(int p_repeatcount)
    {
        RepeatCount = p_repeatcount;
        m_CurrentRepeatCount = RepeatCount;
    }
    void ResetCurrentSec()
    {
        m_CurrentSec = DelaySec;
    }

    public void CallFN()
    {
        //GameObject.Destroy(this.gameObject);
        if(onDelayCallFN != null)
        {
            onDelayCallFN.Invoke();
            
            {
                ResetCurrentSec();
            }
        }
    }

    void Update()
    {
        m_CurrentSec -= Time.deltaTime;
        if (m_CurrentSec <= 0f)
        {
            if (RepeatCount <= 0)
            {
                CallFN();
            }
            else
            {
                if(m_CurrentRepeatCount > 0)
                {
                    CallFN();
                }
            }
            --m_CurrentRepeatCount;
        }

    }
}
