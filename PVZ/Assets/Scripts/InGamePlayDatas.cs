using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGamePlayDatas : SingleTon_Mono<InGamePlayDatas>
{
    //public static int PlayerCoinval = 0;

    [SerializeField]
    protected int m_PlayerCoin = 50;
    public void AddPlayerCoin(int p_coin)
    {
        m_PlayerCoin += p_coin;
        //UIUpdate();
    }



    public int GetCoin()
    {
        return m_PlayerCoin;
    }

    private void Awake()
    {
        m_PlayerCoin = 50;
    }


    void Update()
    {
        
    }
}
