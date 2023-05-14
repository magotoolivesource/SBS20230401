using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Test_String2Int : MonoBehaviour
{
    public int XX = 0;
    public int YY = 0;


    [ContextMenu("[확인용2]")]
    protected void TestDivString()
    {
        // 정규 표현식
        // te.st@gmai.com
        // 010-1234-1234
        // 011 234 1234
        // 010 1234 1234
        // 01012341234
        // abc 1234 gadf
        // +821053503790

        string tempstr = "Mine_[32, 102]";
        string tempstr2 = tempstr.Substring(6);

        // "3, 1]"
        int pos = tempstr2.IndexOf(']');
        string tempstr3 = tempstr2.Substring(0, pos);

        // 3, 1
        string[] splite = tempstr3.Split(",");


        XX = int.Parse( splite[0] );
        YY = System.Convert.ToInt32(splite[1]);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
