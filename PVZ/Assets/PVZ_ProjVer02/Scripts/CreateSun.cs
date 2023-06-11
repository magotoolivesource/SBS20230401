using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class StateSunData
{
    public float DealySec = 3f;
    public float SunCreateDistance = 2f;
    public string LoadPath = "Prefabs/Sun";
}


public class CreateSun : MonoBehaviour
{
    public StateSunData m_StateData;


    protected IEnumerator StartDelayCortoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(m_StateData.DealySec);
            CreateSunFN();
        }
    }


    protected virtual string LoadPath
    {
        get { return m_StateData.LoadPath; }
    }

    protected virtual void CreateSunFN()
    {
        SelectSun resourcesum = Resources.Load<SelectSun>(LoadPath);

        SelectSun clonesun = GameObject.Instantiate(resourcesum);
        clonesun.transform.position = transform.position;

        Vector3 randompos = Random.insideUnitCircle * m_StateData.SunCreateDistance;
    }

    protected void Start()
    {
        StartCoroutine( StartDelayCortoutine() );
    }
    
    void Update()
    {
        
    }
}
