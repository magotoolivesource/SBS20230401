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

    [Header("�׽�Ʈ���")]
    public float _TestCode_Rot = 0f;

    void UpdateFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �߻�ü�� ����
            Rigidbody copyobj = GameObject.Instantiate(ShellObj
                , BulletPos.position
                , BulletPos.rotation );

            // Ȱ��ȭ
            copyobj.gameObject.SetActive(true);
            
            // �߻�ü �߻��ϱ�
            copyobj.AddForce( BulletPos.forward * Pow);
        }
    }


    private void Awake()
    {
        // ���������� �̵���ŵ�ϴ�
        ShellObj.gameObject.SetActive(false);
    }

    void Start()
    {

    }

    void UpdateUnityAPI()
    {
        // �̵�
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        transform.Translate(xx * MoveSpeed * Time.deltaTime
                , 0f, zz * MoveSpeed * Time.deltaTime);

        // ȸ��
        float rot = Input.GetAxis("ROTADD");
        _TestCode_Rot = rot * RotSpeed * Time.deltaTime;
        transform.Rotate(0f, rot, 0f);
        //Debug.Log( $"{rot}" );

    }

    void Update()
    {
        // �̵� ��Ʈ��
        UpdateUnityAPI();

        // �߻� 
        UpdateFire();
    }
}
