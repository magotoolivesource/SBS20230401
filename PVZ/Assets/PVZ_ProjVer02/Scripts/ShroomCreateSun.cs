using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomCreateSun : CreateSun
{
    protected override string LoadPath
    {
        get { return "Prefabs/ShroomCoin"; }
    }

    protected override void CreateSunFN()
    {
        base.CreateSunFN();
    }

    //protected void Start()
    //{
    //    StartCoroutine(StartDelayCortoutine());
    //}

    void Update()
    {
        
    }
}
