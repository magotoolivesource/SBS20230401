using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank2 : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float RotSpeed = 1f;

    public Rigidbody ShellObj = null;
    public float Pow = 100;
    public Transform BulletPos = null;

    [Header("테스트용들")]
    public float _TestCode_Rot = 0f;

    void UpdateFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 발사체를 복사
            Rigidbody copyobj = GameObject.Instantiate(ShellObj
                , BulletPos.position
                , BulletPos.rotation );

            // 활성화
            copyobj.gameObject.SetActive(true);
            
            // 발사체 발사하기
            copyobj.AddForce( BulletPos.forward * Pow);
        }
    }


    private void Awake()
    {
        // 프리팹으로 이동시킵니다
        ShellObj.gameObject.SetActive(false);
    }

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

    void Update()
    {
        // 이동 컨트롤
        UpdateUnityAPI();

        // 발사 
        UpdateFire();
    }
}
