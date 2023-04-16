using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{


    void Start()
    {
        int tempval;
        int tempval2;
        Update2(out tempval);
    }

    void Update2( out int p_val )
    {
        p_val = 20;
    }

    public LineRenderer m_LinkLine = null;
    public Transform ShotTrans;
    public float LineDist = 100f;

    Vector3 m_Test_HitPos = Vector3.zero;
    void UpdateShot()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = new Ray();
            ray.origin = ShotTrans.position;
            ray.direction = ShotTrans.forward;

            RaycastHit hitinfo;
            if( Physics.Raycast(ray, out hitinfo, LineDist) )
            {
                m_Test_HitPos = hitinfo.transform.position;
                m_Test_HitPos = hitinfo.point;
                Debug.Log( $"충돌됨 : {hitinfo.transform.name} ");
            }

            // 라인 그리기
            m_LinkLine.SetPosition(0, ShotTrans.position);
            m_LinkLine.SetPosition(1, ShotTrans.position + (ShotTrans.forward * LineDist));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(m_Test_HitPos, Vector3.one);
    }

    void Update()
    {
        UpdateShot();

    }
}
