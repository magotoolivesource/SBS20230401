using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    // 해바라기


    public float EventDelaySec = 1f;

    protected float m_NextSec = 0;

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
