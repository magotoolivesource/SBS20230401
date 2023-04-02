using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 충돌");
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("컬리젼 충돌");
        GameObject.Destroy( this.gameObject );

        // 벽, 벽 (1)
        string tempsr = "005 벽 005";
        if( tempsr.IndexOf("벽") >= 0 )
        {

        }


        if ( other.gameObject.tag == "Wall"  )
        {
            GameObject.Destroy(other.gameObject);
        }
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
