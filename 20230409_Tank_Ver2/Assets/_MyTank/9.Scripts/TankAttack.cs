using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankAttack : MonoBehaviour
{

    public Rigidbody BulletShell = null;
    public Transform BulletTrans = null;
    public float Pow = 2f;

    // 스페이스바 클릭시 발사
    // 

    void Start()
    {
        //UIPowerSlider.gameObject.SetActive(false);
    }

    bool m_ISPress = false;
    float m_PreseeSec = 0f;

    public float MinPressSec = 0.2f;
    public float MaxPressSec = 2f;

    [SerializeField]
    private float m_PressWeight = 0f;


    public Slider UIPowerSlider = null;

    void UpdateControl()
    {

        if( Input.GetKeyDown(KeyCode.Space) )
        {
            m_ISPress = true;
            m_PreseeSec = Time.time; // 소수점
            
        }

        if(m_ISPress)
        {
            float reminesec = Time.time - m_PreseeSec;

            m_PressWeight = 0.5f;
            if (reminesec >= 2f)
                m_PressWeight = 1f;
            else if (reminesec >= 0.2f)
            {
                float div = 1 / (2 - 0.2f);
                m_PressWeight = Mathf.Lerp(0.5f, 1f, (reminesec - 0.2f) * div);
            }

            UIPowerSlider.value = m_PressWeight;
        }

        if( Input.GetKeyUp(KeyCode.Space) )
        {
            float reminesec = Time.time - m_PreseeSec;

            m_PressWeight = 0.5f;
            if (reminesec >= 2f)
                m_PressWeight = 1f;
            else if(reminesec >= 0.2f)
            {
                float div = 1 / (2 - 0.2f);
                m_PressWeight = Mathf.Lerp(0.5f, 1f, (reminesec - 0.2f) * div );
            }

            m_ISPress = false;
            UIPowerSlider.value = m_PressWeight;
            SetAttack(m_PressWeight);
        }

    }
    void SetAttack(float p_weight)
    {
        Rigidbody cloneobj = GameObject.Instantiate(BulletShell);

        //cloneobj.gameObject.SetActive(true);
        cloneobj.transform.position = BulletTrans.position;
        cloneobj.transform.rotation = Quaternion.LookRotation(BulletTrans.forward);

        cloneobj.AddForce(BulletTrans.forward * Pow * p_weight
            , ForceMode.Impulse);
    }

    void Update()
    {
        UpdateControl();

    }
}
