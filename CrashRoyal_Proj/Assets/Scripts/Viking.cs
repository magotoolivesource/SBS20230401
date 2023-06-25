using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Viking : MonoBehaviour
{
    public Transform Target = null;
    public float MoveSpeed = 1f;
    public bool ISMove = true;

    // 공격 정보
    [Header("[공격범위들]")]
    public float AttackRange = 1f;
    public float AttackDealySec = 1f;
    //public float AttackingDelaySec = 0.5f;
    public float Atk = 1f;
    public Tower AttackTarget = null;
    public bool ISAttack = false;
    


    [Header("[확인용값들]")]
    [SerializeField]
    protected float m_RemineAttackSec = 0f;


    private void OnTriggerEnter(Collider other)
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
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"빠져나감 : {this.name}, {other.transform.name} ");
        if ( AttackTarget == null )
            return;

        Tower tower = other.GetComponent<Tower>();
        if( tower == AttackTarget )
        {
            ISAttack = false;
            AttackTarget = null;
            ISMove = true;
        }
    }






    void Start()
    {
        m_LinkAgent = GetComponent<NavMeshAgent>();
        m_LinkAgent.speed = MoveSpeed;

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

    void UpdateAttack()
    {
        m_RemineAttackSec -= Time.deltaTime;

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
        UpdateDirectTarget();
        UpdateAttack();

        //UpdateAgent();

    }
}
