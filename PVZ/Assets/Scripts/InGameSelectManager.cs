using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PlantType
{
    SUNFollower, // 코인 1개짜리 해바리기
    //DoubleSubFolloer, // 코인 2개짜리 해바리기

    ShotFollwer, // 발사체 식물

    MAX,
}

public class InGameSelectManager : SingleTon_Mono<InGameSelectManager>
{
    public E_PlantType SelectPlantType = E_PlantType.MAX;


    #region 식물 생성 방법1


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

    #region 식물 생성 방법2
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

        // Resources 폴더가 있어야지됨, 경로명과 이름만 입력한다. 확장자는 사용하지 않는다
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

