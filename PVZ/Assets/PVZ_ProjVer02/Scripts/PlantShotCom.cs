using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShotCom : MonoBehaviour
{
    public Transform ShootPos;
    public string LoadShotPath = "";

    public void _On_SetAttack()
    {
        SetAttack();
    }

    public void SetAttack()
    {
        //GameObject.Instantiate();

        MoveShoot shot = Resources.Load<MoveShoot>(LoadShotPath);
        MoveShoot cloneshot = GameObject.Instantiate(shot);
        cloneshot.transform.position = ShootPos.position;

    }

    void Start()
    {
        ShootPos = transform.Find("ShootPos");

    }
    
    void Update()
    {
        
    }
}
