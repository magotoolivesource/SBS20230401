using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestZombi : MonoBehaviour
{
    public int AttackVal = 1;
    public virtual void Attack()
    {
        Debug.Log( $"{this.name} 공격 : {AttackVal}" );
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.T))
        {
            this.Attack();
        }
    }
}
