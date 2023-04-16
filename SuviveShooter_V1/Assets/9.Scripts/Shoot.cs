using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{


    void Start()
    {
        m_LinkLine.gameObject.SetActive(false);
    }

    #region 샷딜레이용

    [Header("[샷관련딜레이값]")]
    public float ShotDelySec = 1f;
    float m_ShotRemineSec = 0f;

    #endregion



    [Header("[라인관련]")]
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
                Debug.Log( $"충돌됨 : {hitinfo.transform.name} ");

                lineendpos = hitinfo.point;


                // 파티클 생성이후 3초후 지우기
                ParticleSystem cloneobj = GameObject.Instantiate(HitParticle
                    , hitinfo.point
                    , Quaternion.identity );
                cloneobj.transform.rotation = Quaternion.LookRotation(hitinfo.normal);
                cloneobj.Play();

                GameObject.Destroy(cloneobj.gameObject, 3);
            }

            // 라인 그리기
            m_LinkLine.SetPosition(0, ShotTrans.position);
            m_LinkLine.SetPosition(1, lineendpos);

        }
    }

    [Header("[라인보이는시간]")]
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
