using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    // 스페이스바 클릭시 발사
    // 

    void Start()
    {
        
    }

    void UpdateControl()
    {
        if( Input.GetKeyDown(KeyCode.Space) )
        {
            SetAttack();
        }
    }
    void SetAttack()
    {

    }

    void Update()
    {
        UpdateControl();

    }
}
