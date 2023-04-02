using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public Rigidbody LinkRigid = null;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(this.gameObject);
    }



    void Start()
    {
        LinkRigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if( LinkRigid.velocity.sqrMagnitude > 0.001f )
        {
            transform.rotation = Quaternion.LookRotation(LinkRigid.velocity);
        }
        
        

    }
}
