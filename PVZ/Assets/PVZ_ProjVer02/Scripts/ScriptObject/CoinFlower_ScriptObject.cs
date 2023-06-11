using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="생성/코인데이터", order = 2)]
public class CoinFlower_ScriptObject : ScriptableObject
{
    public float DealySec = 3f;
    public float SunCreateDistance = 2f;

    public string ResourceName = "";
    public SelectSun CreateResourceCom = null;


    [ContextMenu("[저장하기]")]
    private void _Editor_SaveData()
    {
        Debug.Log("가나다");
    }

}
