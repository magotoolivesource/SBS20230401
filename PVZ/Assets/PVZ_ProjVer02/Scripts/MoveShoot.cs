using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveShoot : MonoBehaviour
{
    public float MoveSpeed = 1f;

    protected void nTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("부딪힘");


        SetDestroy();
    }

    void SetDestroy()
    {
        GameObject.Destroy(gameObject);
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(MoveSpeed * Time.deltaTime, 0f, 0f);

        if( transform.position.x > 15f )
        {
            SetDestroy();
        }
    }
}
