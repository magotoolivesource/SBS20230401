using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingleTon_Mono<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T m_Instance = null;

    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                ////1 직접 코드를 이용해서 생성 해서 가르키도록 하는 방법
                //GameObject obj = new GameObject();
                //Test_SingleTon.m_Instance = obj.AddComponent<Test_SingleTon>();


                // 2번째 방식
                m_Instance = GameObject.FindObjectOfType<T>();
                //GameObject.DontDestroyOnLoad(m_Instance);
            }

            return m_Instance;
        }
    }
    public static T GetInstance()
    {
        if ( m_Instance == null)
        {
            ////1 직접 코드를 이용해서 생성 해서 가르키도록 하는 방법
            //GameObject obj = new GameObject();
            //Test_SingleTon.m_Instance = obj.AddComponent<Test_SingleTon>();


            // 2번째 방식
            m_Instance = GameObject.FindObjectOfType<T>();

            GameObject.DontDestroyOnLoad(m_Instance);
        }

        return m_Instance;
    }
}
