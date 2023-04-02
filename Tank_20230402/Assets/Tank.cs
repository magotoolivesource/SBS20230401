using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public float RotSpeed = 1f;


    public float _TestCode_Rot = 0f;

    void Start()
    {
        
    }

    void UpdateUnityAPI()
    {
        // 이동
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        transform.Translate(xx * MoveSpeed * Time.deltaTime
                , 0f, zz * MoveSpeed * Time.deltaTime);

        // 회전
        float rot = Input.GetAxis("ROTADD");
        _TestCode_Rot = rot * RotSpeed * Time.deltaTime;
        transform.Rotate(0f, rot, 0f);
        //Debug.Log( $"{rot}" );

    }

    void UpdateCodeType()
    {
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        Vector3 temppos = transform.localPosition;
        Vector3 directionvec = new Vector3(xx * MoveSpeed * Time.deltaTime
                    , 0f
                    , zz * MoveSpeed * Time.deltaTime);
        directionvec = transform.rotation * directionvec;

        temppos += directionvec;
        transform.localPosition = temppos;
    }

    // Update is called once per frame
    void Update()
    {
        // 각도
        // 
        UpdateUnityAPI();


    }
}
