using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    // �����̽��� Ŭ���� �߻�
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
