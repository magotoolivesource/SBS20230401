using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ʈ���� �浹");
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("�ø��� �浹");
        GameObject.Destroy( this.gameObject );

        // ��, �� (1)
        string tempsr = "005 �� 005";
        if( tempsr.IndexOf("��") >= 0 )
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
