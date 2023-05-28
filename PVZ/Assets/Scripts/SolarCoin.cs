using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCoin : MonoBehaviour
{
    [SerializeField]
    protected float DestroySec = 10f;
    
    private void OnMouseDown()
    {
        Debug.Log("코인 1개 채워짐");

        InGamePlayDatas.GetInstance().AddPlayerCoin(1);

        GameObject.Destroy(this.gameObject);
    }


    void Start()
    {
        GameObject.Destroy(this.gameObject, DestroySec);
    }

    
    void Update()
    {
        
    }
}
