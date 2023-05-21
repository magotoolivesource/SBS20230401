using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Timer : MonoBehaviour
{

    public Text m_LinkTimerText = null;
    public int m_TimerSec = 0;
    public float m_CurrentTimer = 0f;



    //IEnumerator GetUICheck()
    //{
    //    int result = ShowWindow();

    //    yield return ShowWindow();

    //    if( result )
    //    {
    //        yield return OKWindow();
    //    }
    //    else
    //    {
    //        yield return CancelWindow();
    //    }


    //}


    bool m_ISGameOver = false;

    IEnumerator TimerCoroutine()
    {
        yield return null;
        Time.timeScale = 0f;

        yield return new WaitForSeconds(2f);
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1f;

        int count = 0;
        while(true)
        {
            Debug.Log( $"内风凭 : {count++}");
            yield return new WaitForSeconds(1f);
            if (m_ISGameOver)
            {
                yield break;
            }
                

            m_LinkTimerText.text = $"Timer:{count}";
        }

        yield break;

        yield return null;

        Debug.Log($"内风凭 : {count++}");


    }

    int m_UpdateCount = 0;
    void Update()
    {
        Debug.Log($"诀单捞飘 : {m_UpdateCount++}");

        // 规过1
        //UpdateTimer01();
    }

    private void Awake()
    {

        m_LinkTimerText = GetComponent<Text>();
        m_LinkTimerText.text = $"Timer:{m_TimerSec}";


        StartCoroutine( TimerCoroutine() );

        // 规过2 锅
        //this.InvokeRepeating("UpdateTimer", 0f, 1f);
    }
    
    void UpdateTimer()
    {
        ++m_TimerSec;
        m_LinkTimerText.text = $"Timer:{m_TimerSec}";
    }

    void UpdateTimer01()
    {
        //规过 1
        // 0.999f + 0.5f;
        m_CurrentTimer += Time.deltaTime;
        if (m_CurrentTimer > 1f)
        {
            m_CurrentTimer = m_CurrentTimer - 1f;
            ++m_TimerSec;
            m_LinkTimerText.text = $"Timer:{m_TimerSec}";
        }
    }

    
}
