using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public float RotSpeed = 1f;

    public Rigidbody LinkRigid = null;
    public Vector3 Direction = new Vector3(0, 1, 1);
    public float Pow = 100;
    public Transform BulletPos = null;

    [Header("�׽�Ʈ���")]
    public float _TestCode_Rot = 0f;

    void UpdateFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //LinkRigid.AddForce(Direction * Pow);

            // ��� 1
            Vector3 direction2 = transform.rotation * Direction;

            // �߻�ü�� ����
            Rigidbody copyobj = GameObject.Instantiate( LinkRigid
                , BulletPos.position
                , Quaternion.identity );
            copyobj.gameObject.SetActive(true);
            //copyobj.position = BulletPos.position;

            copyobj.AddForce(BulletPos.up * Pow );
        }

    }


    private void Awake()
    {
        // ���������� �̵���ŵ�ϴ�
        LinkRigid.gameObject.SetActive(false);
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

    void Update()
    {
        // ����
        // 
        UpdateUnityAPI();

        UpdateFire();
    }
}
