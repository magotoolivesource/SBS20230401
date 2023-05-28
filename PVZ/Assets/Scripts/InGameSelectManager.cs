using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PlantType
{
    SUNFollower, // ���� 1��¥�� �عٸ���
    //DoubleSubFolloer, // ���� 2��¥�� �عٸ���

    ShotFollwer, // �߻�ü �Ĺ�

    MAX,
}

public class InGameSelectManager : SingleTon_Mono<InGameSelectManager>
{
    public E_PlantType SelectPlantType = E_PlantType.MAX;


    #region �Ĺ� ���� ���1


    // 
    public GameObject SunFollowerObj = null;

    public GameObject ClonePlant()
    {
        GameObject cloneobj = null;
        switch (SelectPlantType)
        {
            case E_PlantType.SUNFollower:
                cloneobj = GameObject.Instantiate(SunFollowerObj);
                break;
            case E_PlantType.ShotFollwer:
                break;
            case E_PlantType.MAX:
                break;
            default:
                break;
        }

        return cloneobj;
    }


    #endregion

    #region �Ĺ� ���� ���2
    public GameObject ClonePlantResourceData()
    {

        //string loadpath = "";
        //switch (SelectPlantType)
        //{
        //    case E_PlantType.SUNFollower:
        //        loadpath = "Temp_Follower";
        //        break;
        //    case E_PlantType.ShotFollwer:
        //        loadpath = "Temp_ShotFollower";
        //        break;
        //    case E_PlantType.MAX:
        //        break;
        //    default:
        //        break;
        //}

        string loadpath = $"Temp_{SelectPlantType}";

        // Resources ������ �־������, ��θ�� �̸��� �Է��Ѵ�. Ȯ���ڴ� ������� �ʴ´�
        GameObject resourceobj = Resources.Load(loadpath) as GameObject;

        GameObject cloneobj = null;
        if ( resourceobj != null )
        {
            cloneobj = GameObject.Instantiate(resourceobj);
        }

        return cloneobj;
    }


    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

