using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellCompoment : MonoBehaviour
{
    public GameObject ShellExpolistion = null;
    // 충돌시 처리할것들
    void OnCollisionEnter(Collision collision)
    {
        
        GameObject expolistionclone = GameObject.Instantiate(ShellExpolistion
            , transform.position
            , Quaternion.identity);

        // 폭발 방법 1
        if ( false )
        {
            ParticleSystem system = expolistionclone.GetComponent<ParticleSystem>();
            system.Play();
            GameObject.Destroy(expolistionclone, 5f);
        }
        


        // 자신을파괴
        GameObject.Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        
    }


    Rigidbody m_LinkRigidBody = null;
    void Start()
    {
        m_LinkRigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        if(m_LinkRigidBody.velocity.magnitude >= 0.001f )
        {
            transform.rotation = Quaternion.LookRotation(m_LinkRigidBody.velocity);
        }
        
    }
}
