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
            ////1 직접 코드를 이용해서 생성 해서 가르키도록 하는 방법
            //GameObject obj = new GameObject();
            //Test_SingleTon.m_Instance = obj.AddComponent<Test_SingleTon>();


            // 2번째 방식
            Test_SingleTon.m_Instance = GameObject.FindObjectOfType<Test_SingleTon>();

            GameObject.DontDestroyOnLoad(Test_SingleTon.m_Instance);
        }

        return m_Instance;
    }



    public void TestCallFN()
    {
        Debug.Log("함수 호출");
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
