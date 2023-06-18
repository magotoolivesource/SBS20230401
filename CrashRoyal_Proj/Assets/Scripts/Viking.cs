using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Viking : MonoBehaviour
{
    public Transform Target = null;
    public float MoveSpeed = 1f;

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

    void Update()
    {
        //UpdateDirectTarget();
        UpdateAgent();

    }
}
