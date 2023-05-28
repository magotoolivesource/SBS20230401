using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Bullet : MonoBehaviour
{

    public float MoveSpeed = 1f;
    
    void Start()
    {
        Destroy(gameObject, 10f);

    }

    
    protected void UpdaetMove()
    {
        //Vector3 pos = transform.position;
        //pos.x += Time.deltaTime * MoveSpeed;
        //transform.position = pos;

        transform.Translate(Time.deltaTime * MoveSpeed, 0f, 0f);
    }

    void Update()
    {
        UpdaetMove();

    }
}
