using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConZombi : TestZombi
{

    public virtual void Attack()
    {
        Debug.Log($"상속 좀비 공격 : {AttackVal}");
        base.Attack();
    }


    public void AttackCon()
    {
        Debug.Log($"콘으로 공격 : {AttackVal}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.Attack();
        }
    }
}
