using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellCompoment : MonoBehaviour
{
    public GameObject ShellExpolistion = null;
    // �浹�� ó���Ұ͵�
    void OnCollisionEnter(Collision collision)
    {
        
        GameObject expolistionclone = GameObject.Instantiate(ShellExpolistion
            , transform.position
            , Quaternion.identity);

        // ���� ��� 1
        if ( false )
        {
            ParticleSystem system = expolistionclone.GetComponent<ParticleSystem>();
            system.Play();
            GameObject.Destroy(expolistionclone, 5f);
        }
        


        // �ڽ����ı�
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
