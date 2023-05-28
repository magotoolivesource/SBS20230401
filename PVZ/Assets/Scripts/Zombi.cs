using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public int HP = 3;
    Rigidbody2D m_LinkBody2D = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Plant_Bullet bullet = collision.GetComponent<Plant_Bullet>();

        if(bullet == null)
        {
            return;
        }

        HP -= (int)bullet.Damage;

        if( HP <= 0)
        {
            GameObject.Destroy( gameObject );
        }
    }


    private void Awake()
    {
        m_LinkBody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {

        //m_LinkBody2D.MovePosition()

        transform.Translate(-MoveSpeed * Time.deltaTime, 0f, 0f);
    }
}
