using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class RangeTrigger : MonoBehaviour
{
    [System.Serializable]
    public class ColliderTriggerEvent : UnityEvent<Collider>
    {
        //public ColliderTriggerEvent();
    }


    //Action<Collider> m_LilkEvent = null;

    public float Radius = 1f;
    [Header("[충돌시]")]
    public ColliderTriggerEvent TriggerEnterEvent;
    [Header("[충돌종료]")]
    public ColliderTriggerEvent TriggerExitEvent;


    private void OnTriggerEnter(Collider other)
    {
        //Button btn;
        //btn.onClick.AddListener()

        Debug.Log("충돌002");
        TriggerEnterEvent.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("빠져나감002");
        TriggerExitEvent.Invoke(other);
    }

    void Start()
    {
        GetComponent<SphereCollider>().radius = Radius;
        GetComponent<SphereCollider>().isTrigger = true;
        GetComponent<Rigidbody>().useGravity = false;

    }
    
    void Update()
    {
        
    }
}
