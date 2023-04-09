using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[HelpURL("https://www.naver.com")]
public class TankControlMove : MonoBehaviour
{
    [SerializeField]
    protected float TempVal = 10;

    public float MoveSpeed = 1f;
    public float RotSpeed = 1f;

    void Start()
    {
        
    }

    void UpdateControl()
    {
        float zz = Input.GetAxis("Vertical");
        float h_rot = Input.GetAxis("Horizontal");

        UpdateMove( zz * MoveSpeed * Time.deltaTime
            , h_rot * RotSpeed * Time.deltaTime );
    }

    void UpdateMove( float p_z, float p_hrot )
    {
        transform.Translate(0f, 0f, p_z);
        transform.Rotate(0f, p_hrot, 0f);
    }

    void Update()
    {
        UpdateControl();

    }
}
