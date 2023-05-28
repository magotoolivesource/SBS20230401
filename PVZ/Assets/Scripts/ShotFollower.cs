using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotFollower : MonoBehaviour
{

    public float DelaySec = 1;

    [SerializeField]
    protected Transform ChildBulletPos = null;

    // 코루틴 방식으로 처리
    IEnumerator PlantsShotCortinue()
    {
        while(true)
        {
            yield return new WaitForSeconds( DelaySec );
            Shot();
        }

    }
    
    protected void Shot()
    {
        Plant_Bullet bullet = Resources.Load<Plant_Bullet>("PlentBullet");
        Plant_Bullet cloneobj = GameObject.Instantiate(bullet);
        cloneobj.transform.position = ChildBulletPos.position;

    }

    private void Awake()
    {
        ChildBulletPos = this.transform.Find("BulletPos");

    }
    void Start()
    {
        StartCoroutine( PlantsShotCortinue() );

    }

    
    void Update()
    {
        
    }
}
