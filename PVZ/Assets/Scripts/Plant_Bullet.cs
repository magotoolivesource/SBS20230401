using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Bullet : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public float Damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Zombi zombi = collision.GetComponent<Zombi>();

        if( zombi == null )
        {
            return;
        }

        GameObject.Destroy(gameObject);
    }





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
