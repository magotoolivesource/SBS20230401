using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSun : MonoBehaviour
{

    public float DealySec = 3f;
    public float SunCreateDistance = 2f;


    IEnumerator StartDelayCortoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(DealySec);
            CreateSunFN();
        }
    }

    void CreateSunFN()
    {
        SelectSun resourcesum = Resources.Load<SelectSun>("Prefabs/Sun");

        SelectSun clonesun = GameObject.Instantiate(resourcesum);
        clonesun.transform.position = transform.position;


        Vector3 randompos = Random.insideUnitCircle * SunCreateDistance;
        //clonesun.GetComponent<MoveTween>().InitMove(transform.position
        //    , transform.position + randompos
        //    , 2f);

        clonesun.GetComponent<MoveDoTween>().Init( transform.position
            , transform.position + randompos
            , 2f );

    }

    void Start()
    {
        StartCoroutine( StartDelayCortoutine() );
    }
    
    void Update()
    {
        
    }
}
