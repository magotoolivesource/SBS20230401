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


    [Header("[확인용]")]
    [SerializeField]
    protected float m_CurrentSec = 0f;

    void Start()
    {
        m_CurrentSec = DelaySec;
    }
    
    public void CallFN()
    {
        //GameObject.Destroy(this.gameObject);
        if(onDelayCallFN != null)
        {
            onDelayCallFN.Invoke();
        }
    }

    void Update()
    {
        m_CurrentSec -= Time.deltaTime;
        if (m_CurrentSec <= 0f)
        {
            CallFN();
        }

    }
}
