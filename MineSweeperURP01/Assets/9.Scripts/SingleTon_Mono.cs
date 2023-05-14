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
                ////1 ���� �ڵ带 �̿��ؼ� ���� �ؼ� ����Ű���� �ϴ� ���
                //GameObject obj = new GameObject();
                //Test_SingleTon.m_Instance = obj.AddComponent<Test_SingleTon>();


                // 2��° ���
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
            ////1 ���� �ڵ带 �̿��ؼ� ���� �ؼ� ����Ű���� �ϴ� ���
            //GameObject obj = new GameObject();
            //Test_SingleTon.m_Instance = obj.AddComponent<Test_SingleTon>();


            // 2��° ���
            m_Instance = GameObject.FindObjectOfType<T>();

            GameObject.DontDestroyOnLoad(m_Instance);
        }

        return m_Instance;
    }
}
