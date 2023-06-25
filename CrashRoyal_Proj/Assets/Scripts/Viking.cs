using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Viking : MonoBehaviour
{
    public Transform Target = null;
    public float MoveSpeed = 1f;
    public bool ISMove = true;


    [Header("[찾기범위]")]
    public float SearchingRange = 2f;
    public Tower SearchingTarget = null;


    // 공격 정보
    [Header("[공격범위들]")]
    public float AttackRange = 1f;
    public float AttackDealySec = 1f;
    //public float AttackingDelaySec = 0.5f;
    public float Atk = 1f;
    public Tower AttackTarget = null;
    public bool ISAttack = false;




    [SerializeField]
    protected DelayEventCom m_LinkDelayEventCom = null;

    [SerializeField]
    protected DelayEventCom m_LinkDelayEventCom2 = null;


    [Header("[확인용값들]")]
    [SerializeField]
    protected float m_RemineAttackSec = 0f;
    [SerializeField]
    protected Coroutine m_AttackCoroutine = null;
    protected float m_AttackStopSec = 0f;

    private void OnTriggerEnter(Collider other)
    {
    }
    private void OnTriggerExit(Collider other)
    {
    }



    public void _MyOn_RangeTriggerEnter(Collider other)
    {
        Debug.Log($"범위 : {this.name}, {other.transform.name} ");
    }

    public void _MyOn_RangeTriggerExit(Collider other)
    {
        Debug.Log($"범위 해제 : {this.name}, {other.transform.name} ");
    }

    public void _MyOn_AttackTriggerEnter(Collider other)
    {
        Debug.Log($"충돌됨 : {this.name}, {other.transform.name} ");
        Tower tower = other.GetComponent<Tower>();
        if (tower == null)
        {
            return;
        }

        ISMove = false;
        ISAttack = true;
        AttackTarget = tower;
        //m_AttackCoroutine = StartCoroutine(AttackCoroutinue());


        m_LinkDelayEventCom.InitSettings(5f);
        m_LinkDelayEventCom.DelayCallFN.AddListener( SetAttackCall );
        m_LinkDelayEventCom.DelayCallCourtinue();
        //m_LinkDelayEventCom.enabled = true;

        m_LinkDelayEventCom2.DelayCallFN.AddListener(SetAttackCall);
        m_LinkDelayEventCom2.DelayCallCourtinue();
    }

    public void _MyOn_AttackTriggerExit(Collider other)
    {
        Debug.Log($"빠져나감 : {this.name}, {other.transform.name} ");
        if (AttackTarget == null)
            return;

        Tower tower = other.GetComponent<Tower>();
        if (tower == AttackTarget)
        {
            ISAttack = false;
            AttackTarget = null;
            ISMove = true;

            if (m_AttackCoroutine != null)
            {
                //StopCoroutine(m_AttackCoroutine);
                //m_AttackCoroutine = null;
                //m_AttackStopSec = Time.time;


                m_LinkDelayEventCom.DelayCallFN.RemoveListener(SetAttackCall);
                m_LinkDelayEventCom.DelayStopCotrouine();

                m_LinkDelayEventCom2.DelayCallFN.RemoveListener(SetAttackCall);
                m_LinkDelayEventCom2.DelayStopCotrouine();
            }


        }
    }


    void SetAttackCall( DelayEventCom p_com )
    {
        Debug.Log($"공격처리 : {p_com.CallTypeName }, {p_com.DelaySec} ");

    }

    [SerializeField]
    protected RangeTrigger m_AttackTrigger = null;
    void InitAttackRange()
    {
        //GetComponent<SphereCollider>().radius = AttackRange;

        //GetComponentsInChildren<RangeTrigger>();

        m_AttackTrigger.TriggerEnterEvent.AddListener(_MyOn_AttackTriggerEnter);




    }


    void Start()
    {
        m_LinkAgent = GetComponent<NavMeshAgent>();
        m_LinkAgent.speed = MoveSpeed;

        InitAttackRange();
    }

    protected NavMeshAgent m_LinkAgent = null;
    void UpdateAgent()
    {
        if (Target == null)
            return;

        m_LinkAgent.SetDestination( Target.position );
    }

    void UpdateDirectTarget()
    {
        if (Target == null)
            return;

        if (!ISMove)
            return;

        Vector3 targetdirection = Target.position - transform.position;
        Vector3 offsetdir = targetdirection.normalized * MoveSpeed * Time.deltaTime;

        if( targetdirection.magnitude < offsetdir.magnitude )
        {
            transform.position = Target.position;
        }
        else
        {
            transform.position = transform.position + offsetdir;
        }
    }


    [SerializeField]
    protected float m_CoroutineSec = 0f;
    IEnumerator AttackCoroutinue()
    {
        m_RemineAttackSec = m_RemineAttackSec - ( Time.time - m_AttackStopSec);
        m_CoroutineSec = m_RemineAttackSec;

        while (true)
        {
            m_RemineAttackSec -= Time.deltaTime;
            if (m_RemineAttackSec <= 0)
            {
                //SetAttack();
                m_RemineAttackSec = AttackDealySec;
            }

            yield return null;
        }
    }


    void UpdateAttack()
    {
        

        if ( ISAttack == false )
            return;

        if(m_RemineAttackSec <= 0f)
        {
            m_RemineAttackSec = AttackDealySec;
            SetAttack();
        }

        
    }

    void SetAttack()
    {
        Debug.Log("공격하기");
    }

    void Update()
    {
        //m_RemineAttackSec -= Time.deltaTime;
        UpdateDirectTarget();


        //UpdateAttack();

        //UpdateAgent();

    }
}
