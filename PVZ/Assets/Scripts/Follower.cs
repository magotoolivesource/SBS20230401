using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    // 해바라기
    public float EventDelaySec = 1f;
    protected float m_NextSec = 0;

    // 해바라기 코인 값용
    public float range = 2f;

    protected void UpdateEvent()
    {
        if( Time.time > m_NextSec )
        {
            m_NextSec = EventDelaySec + Time.time;

            CreateCoin();
        }
    }

    protected void CreateCoin()
    {
        // 
        Debug.Log("코인 1개 생성");

        GameObject obj = Resources.Load("Solar") as GameObject;
        GameObject clonecoin = GameObject.Instantiate(obj);


        Vector3 randompos = transform.position;
        
        if (false)
        {
            // 방법 1
            randompos.x = randompos.x + Random.Range(-range, range);
            randompos.y = randompos.y + Random.Range(-range, range);
        }
        else
        {
            // 방법2
            Vector3 circlepos = Random.insideUnitCircle * range;
            randompos += circlepos;
        }


        clonecoin.transform.position = randompos;

        //GameObject.Destroy(clonecoin, 5f);

    }


    void Start()
    {
        m_NextSec = EventDelaySec + Time.time;
    }

    
    void Update()
    {
        UpdateEvent();
    }
}
