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

    public Quaternion MyRot;
    public Vector4 TempRot;


    public Vector2 MouseScreenPos;

    public Transform GuideBox;
    void UpdateRotaion()
    {
        


        //MouseScreenPos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;

        if ( Physics.Raycast(ray, out hitinfo, 999f ) )
        {
            Vector3 lookvec = hitinfo.point - transform.position;
            transform.rotation = Quaternion.LookRotation(lookvec, Vector3.up);
        }

        MyRot = transform.rotation;
        TempRot.x = MyRot.x;
        TempRot.y = MyRot.y;
        TempRot.z = MyRot.z;
        TempRot.w = MyRot.w;

        //Quaternion rot = new Quaternion();

        ////transform.rotation;
        ////transform.localRotation;
        ////transform.position = Vector3.zero;
        //transform.rotation = Quaternion.
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(ray.origin, ray.direction * 999f);

        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo, 999f))
        {
            Vector3 lookvec = hitinfo.point - transform.position;

            Gizmos.color = DebugColor;
            Gizmos.DrawWireCube(hitinfo.point, Vector3.one);
        }

        
    }





}
