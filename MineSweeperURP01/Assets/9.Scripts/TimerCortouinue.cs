using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCortouinue : MonoBehaviour
{
    [SerializeField]
    protected Text m_LinkTimerText = null;


    protected IEnumerator UpdateTimer()
    {
        int timer = 0;
        while(true)
        {
            yield return new WaitForSeconds(1f);
            m_LinkTimerText.text = $"경과시간:{timer++}";
        }

    }

    private void Awake()
    {
        m_LinkTimerText = GetComponent<Text>();
        StartCoroutine( UpdateTimer() );
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
