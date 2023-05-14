using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SingleTon : MonoBehaviour
{
    private static Test_SingleTon m_Instance = null;

    public static Test_SingleTon GetInstance()
    {
        if( Test_SingleTon.m_Instance == null )
        {
            ////1 ���� �ڵ带 �̿��ؼ� ���� �ؼ� ����Ű���� �ϴ� ���
            //GameObject obj = new GameObject();
            //Test_SingleTon.m_Instance = obj.AddComponent<Test_SingleTon>();


            // 2��° ���
            Test_SingleTon.m_Instance = GameObject.FindObjectOfType<Test_SingleTon>();

            GameObject.DontDestroyOnLoad(Test_SingleTon.m_Instance);
        }

        return m_Instance;
    }



    public void TestCallFN()
    {
        Debug.Log("�Լ� ȣ��");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
