using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSun : MonoBehaviour
{

    private void OnMouseDown()
    {
        _On_ClickSun();
    }

    public void _On_ClickSun()
    {
        Debug.Log("Sun 클릭적용");
        SetDestroy();
    }

    public void SetDestroy()
    {
        GameObject.Destroy(gameObject);
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
