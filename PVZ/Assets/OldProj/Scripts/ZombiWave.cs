using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiWave : MonoBehaviour
{
    public float DelaySec = 3f;
    public float RandomRange = 1f;

    IEnumerator WaveCortouine()
    {
        while (true)
        {
            float randsec = Random.Range(DelaySec - RandomRange, DelaySec + RandomRange);
            yield return new WaitForSeconds(randsec);
            CreateZombi();
        }

    }
    
    void CreateZombi()
    {
        Zombi zombi = Resources.Load<Zombi>("Zombi/BaseZombi");
        Zombi clonezombi = GameObject.Instantiate(zombi);
        clonezombi.transform.position = transform.position;

    }

    void Start()
    {
        StartCoroutine(WaveCortouine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
