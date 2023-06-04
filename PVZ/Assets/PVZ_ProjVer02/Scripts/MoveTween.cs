using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTween : MonoBehaviour
{
    protected Vector3 m_TargetPos = new Vector3();
    protected Vector3 m_MoveDuration = new Vector3();
    protected float m_RemineSec = 0f;

    public void InitMove( Vector3 p_stpos, Vector3 p_targetpos, float p_durationsec )
    {
        transform.position = p_stpos;
        m_TargetPos = p_targetpos;

        m_RemineSec = p_durationsec;
        Vector3 vec = p_targetpos - p_stpos;
        m_MoveDuration = vec / p_durationsec;
    }

    
    void Update()
    {
        Vector3 temppos = transform.position;
        temppos = temppos + (Time.deltaTime * m_MoveDuration);

        transform.position = temppos;

        m_RemineSec -= Time.deltaTime;
        if( m_RemineSec <= 0f)
        {
            GameObject.Destroy(this);
        }
    }
}
