using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class TimerTask : MonoBehaviour
{
    [SerializeField]
    protected Text m_LinkTimerText = null;

    public async void UpdateTimer()
    {
        int timer = 0;
        while(true)
        {
            await Task.Delay(1000);

            m_LinkTimerText.text = $"경과시간:{timer++}";
        }
    }
    
    void Start()
    {
        m_LinkTimerText = GetComponent<Text>();

        //StartCoroutine() 

        UpdateTimer();

    }

    
    void Update()
    {
        
    }
}
