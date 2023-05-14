using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{


    void Start()
    {
        m_LinkLine.gameObject.SetActive(false);
    }

    #region �������̿�

    [Header("[�����õ����̰�]")]
    public float ShotDelySec = 1f;
    float m_ShotRemineSec = 0f;

    #endregion



    [Header("[���ΰ���]")]
    public LineRenderer m_LinkLine = null;
    public Transform ShotTrans;
    public float LineDist = 100f;

    public ParticleSystem HitParticle = null;

    Vector3 m_Test_HitPos = Vector3.zero;
    void UpdateShot()
    {

        m_ShotRemineSec -= Time.deltaTime;
        if ( m_ShotRemineSec <= 0f
            && Input.GetMouseButton(0) )
        {
            m_ShotRemineSec = ShotDelySec;



            m_LinkLine.gameObject.SetActive(true);
            m_DelayLineSec = LineVisibleSec;

            Ray ray = new Ray();
            ray.origin = ShotTrans.position;
            ray.direction = ShotTrans.forward;

            //Debug.DrawRay(ray.origin, ray.direction, Color.blue, 3f);

            RaycastHit hitinfo;
            Vector3 lineendpos = ShotTrans.position + (ShotTrans.forward * LineDist);
            if ( Physics.Raycast(ray, out hitinfo, LineDist) )
            {
                m_Test_HitPos = hitinfo.transform.position;
                m_Test_HitPos = hitinfo.point;
                Debug.Log( $"�浹�� : {hitinfo.transform.name} ");

                lineendpos = hitinfo.point;


                // ��ƼŬ �������� 3���� �����
                ParticleSystem cloneobj = GameObject.Instantiate(HitParticle
                    , hitinfo.point
                    , Quaternion.identity );
                cloneobj.transform.rotation = Quaternion.LookRotation(hitinfo.normal);
                cloneobj.Play();

                GameObject.Destroy(cloneobj.gameObject, 3);
            }

            // ���� �׸���
            m_LinkLine.SetPosition(0, ShotTrans.position);
            m_LinkLine.SetPosition(1, lineendpos);

        }
    }

    [Header("[���κ��̴½ð�]")]
    public float LineVisibleSec = 0.1f;
    float m_DelayLineSec = 0f;
    void UpdateLineVisible()
    {
        m_DelayLineSec -= Time.deltaTime;
        if ( m_DelayLineSec <= 0f )
        {
            m_LinkLine.gameObject.SetActive(false);
            m_DelayLineSec = 0;
        }
        
    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(m_Test_HitPos, Vector3.one);
    //}

    void Update()
    {
        UpdateShot();
        UpdateLineVisible();
    }
}
