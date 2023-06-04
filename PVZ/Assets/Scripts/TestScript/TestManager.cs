using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{

    public TestZombi Myzombi;
    public TestConZombi MyConzombi;


    public List<TestZombi> MYAllZombiList = new List<TestZombi>();

    void Start()
    {
        Myzombi = GameObject.Find("Zombi").GetComponent<TestZombi>();
        MyConzombi = GameObject.FindObjectOfType<TestConZombi>();

        MYAllZombiList.Add(Myzombi);
        MYAllZombiList.Add(MyConzombi);
    }
    
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.A) )
        {
            //Myzombi.Attack();
            //MyConzombi.Attack();

            foreach (var item in MYAllZombiList)
            {
                item.Attack();

                //TestConZombi conzombi = item as TestConZombi;



                //if(conzombi != null)
                //{
                //    conzombi.Attack();
                //}
                //else
                //{
                //    item.Attack();
                //}


            }
        }
    }
}
