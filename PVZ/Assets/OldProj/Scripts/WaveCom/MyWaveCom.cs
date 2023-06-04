using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 상속
// virtual, overrider
// interface, abstract
// tamplete



[System.Serializable]
public class WaveInfoData
{
    public float DelaySec = 1;
    public List<string> CloneZombiResourceList = new List<string>();
}

public class MyWaveCom : MonoBehaviour
{
    public List<WaveInfoData> m_WaveInfoList = new List<WaveInfoData>();

    protected WaveInfoData m_CurrentWaveInfo = null;
    protected float m_NextSec = 0f;


    IEnumerator WaveCoroutinue()
    {
        //m_CurrentWaveInfo = m_WaveInfoList[0];

        int count = m_WaveInfoList.Count;
        for (int i = 0; i < count; i++)
        {
            m_CurrentWaveInfo = m_WaveInfoList[i];

            yield return new WaitForSeconds(m_CurrentWaveInfo.DelaySec);

            foreach (var item in m_CurrentWaveInfo.CloneZombiResourceList)
            {
                CreateZombi(item);
            }
        }


    }

    void CreateZombi(string p_resourcezombi)
    {

        //GameObject zombi = (GameObject)Resources.Load($"Zombi/{p_resourcezombi}");


        Zombi zombi = Resources.Load<Zombi>( $"Zombi/{p_resourcezombi}" );
        //Zombi_ConHead zombi = Resources.Load<Zombi_ConHead>($"Zombi/{p_resourcezombi}");


        Zombi clonezombi = GameObject.Instantiate(zombi);
        clonezombi.transform.position = transform.position;

    }

    void Awake()
	{
        StartCoroutine(WaveCoroutinue());
	}
    
    //void Start()
    //{
    //    
    //}

    
    void Update()
    {
        
    }
}
