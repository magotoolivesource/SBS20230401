using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SingleTonObj : MonoBehaviour
{

    public Test_SingleTon m_Linkg = null;
    // Start is called before the first frame update
    void Start()
    {
        m_Linkg = Test_SingleTon.GetInstance();

        Test_SingleTon.GetInstance().TestCallFN();

        Test_SingleTon.GetInstance().TestCallFN();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
