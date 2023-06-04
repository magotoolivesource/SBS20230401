using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIHPBarAni : MonoBehaviour
{

    public int HP = 100;
    public float DurationSec = 0.4f;
    public int looptime = 3;

    public Color DamageColor = new Color();

    protected int MaxHP = 100;
    protected Image m_LinkImage = null;

    

    [ContextMenu("[테스트 HP애니메이션]")]
    protected void _Editor_TestAni()
    {
        HP -= 10;
        m_LinkImage = GetComponent<Image>();
        HpBarAni();
    }

    protected void HpBarAni()
    {
        float amount = (float)HP / MaxHP;
        m_LinkImage.DOFillAmount(amount, DurationSec)
            //.SetEase()
            ;

        
        m_LinkImage.DOColor(DamageColor, DurationSec / (looptime * 2))
            .SetLoops(looptime * 2, LoopType.Yoyo);
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            _Editor_TestAni();
        }
    }
}
