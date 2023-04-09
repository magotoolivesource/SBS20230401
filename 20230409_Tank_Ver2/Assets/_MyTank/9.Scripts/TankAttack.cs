using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{

    public Rigidbody BulletShell = null;
    public Transform BulletTrans = null;
    public float Pow = 2f;

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
        Rigidbody cloneobj = GameObject.Instantiate(BulletShell);

        //cloneobj.gameObject.SetActive(true);
        cloneobj.transform.position = BulletTrans.position;
        cloneobj.transform.rotation = Quaternion.LookRotation(BulletTrans.forward);
        

        cloneobj.AddForce(BulletTrans.forward * Pow
            , ForceMode.Impulse);
    }

    void Update()
    {
        UpdateControl();

    }
}
