using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// 다음 시간 할것 7/1날할것
// 코루틴이 아닌 enable방식으로 수정해서 사용하도록하기
public class DelayEventCom : MonoBehaviour
{
    [System.Serializable]
    public class DelayEventCallFN : UnityEvent<DelayEventCom>
    {
    }

    public string CallTypeName = "";
    public float DelaySec = 1f;
    public DelayEventCallFN DelayCallFN = null;


    [Header("[확인용값들]")]
    [SerializeField]
    protected float m_RemineSec = 0f;
    [SerializeField]
    protected Coroutine m_DealyCoroutine = null;
    protected float m_AttackStopSec = 0f;


    bool m_ISStop = false;
    public Coroutine DelayCallCourtinue()
    {
        m_ISStop = true;
        m_DealyCoroutine = StartCoroutine(DelayCoroutinue());
        return m_DealyCoroutine;
    }
    public void DelayStopCotrouine()
    {
        if (m_DealyCoroutine == null)
            return;

        m_ISStop = false;
        StopCoroutine(m_DealyCoroutine);
        m_DealyCoroutine = null;
    }


    [SerializeField]
    protected float m_CoroutineSec = 0f;
    IEnumerator DelayCoroutinue()
    {
        m_RemineSec = m_RemineSec - (Time.time - m_AttackStopSec);

        while (true)
        {
            m_RemineSec -= Time.deltaTime;
            if (m_RemineSec <= 0)
            {
                m_RemineSec = DelaySec;
                DelayCallFN.Invoke(this);
            }

            if( !m_ISStop )
            {
                break;
            }

            yield return null;
        }

        m_DealyCoroutine = null;
    }


    public void InitSettings( float p_delaysec
        , UnityAction<DelayEventCom> p_callfn = null )
    {
        DelaySec = p_delaysec;

        if(p_callfn != null)
            DelayCallFN.AddListener(p_callfn);
    }

    void Start()
    {
        
    }
    
}
