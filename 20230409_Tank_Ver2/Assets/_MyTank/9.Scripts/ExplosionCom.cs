using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCom : MonoBehaviour
{

    private void Awake()
    {
        // lerp
        // tween

        this.GetComponent<ParticleSystem>().Play();
        GameObject.Destroy(this.gameObject, 4.5f);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
