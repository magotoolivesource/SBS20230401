using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




public class MyCls
{
    public int X;
    public int Y;
}

public class PlayerMove : MonoBehaviour
{
    void Start()
    {
    }
    public float MoveSpeed = 1f;
    void UpdateMove()
    {
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        // 게임엔진
        // transform.Translate();

        Vector3 temppos = transform.position;
        temppos.x += xx * Time.deltaTime * MoveSpeed;
        temppos.z += zz * Time.deltaTime * MoveSpeed;
        transform.position = temppos;

    }

    
    public LayerMask LandMask;
    protected Vector3 m_GizmoeHitPos;
    void UpdateRotaion()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;

        if ( Physics.Raycast(ray, out hitinfo, 999f, LandMask ) )
        {
            m_GizmoeHitPos = hitinfo.point;
            Vector3 lookvec = hitinfo.point - transform.position;
            transform.rotation = Quaternion.LookRotation(lookvec, Vector3.up);
        }

    }

    void TestRayCastHit()
    {
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hitarr = Physics.RaycastAll(ray2, 999);
        // linq
        var sortarr = from item in hitarr
                      orderby (item.point - transform.position).sqrMagnitude 
                      select item;
        sortarr.ToList();
               
    }

    void Update()
    {
        UpdateMove();
        UpdateRotaion();

    }


    [Header("[디버깅용]")]
    public Color DebugColor = Color.red;
    private void OnDrawGizmos()
    {
        Gizmos.color = DebugColor;
        Gizmos.DrawWireCube(m_GizmoeHitPos, Vector3.one * 0.3f);
        
    }





}
