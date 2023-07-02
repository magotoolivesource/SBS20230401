using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerScripts : MonoBehaviour
{

    public LayerMask Maskval;
    void Start()
    {
        string layerstr = LayerMask.LayerToName(7);
        gameObject.layer = LayerMask.NameToLayer("Enemy");


        int val1 = LayerMask.NameToLayer("Enemy");
        int val2 = LayerMask.GetMask("Enemy", "floor");

        int val3 = 1 << 7;

        int val5 =  0100000;
        int val6 = 01000000;

        int val7 = val5 | val6;

        bool[] AllType = new bool[100];
        AllType[0] = true;
        AllType[1] = false;

        bool Enemy = true;


        Debug.Log($"{val1}, {val2}");
    }
    
    void Update()
    {
        
    }
}
