using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{

    public Transform m_Target = null;
    public Vector3 m_Offeset = Vector3.zero;
    public float m_Lerp = 0.2f;

    private void Awake()
    {
        m_Offeset = transform.position - m_Target.position;
    }
    
    void Update()
    {
        // 선형보간, 원형보간
        // tween

        // Vector3.SmoothDamp()
        Vector3 temppos = Vector3.Lerp(transform.position, m_Target.position + m_Offeset, m_Lerp * Time.deltaTime);
        transform.position = temppos;


    }
}
