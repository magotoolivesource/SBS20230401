using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSprite : MonoBehaviour
{

    protected GameObject m_LinkGameObj = null;
    private void OnMouseDown()
    {
        Debug.Log($"클릭 적용됨 : {this.name} ");

        if ( m_LinkGameObj != null )
        {
            return;
        }

        //m_LinkGameObj = InGameSelectManager.GetInstance().ClonePlant();
        //m_LinkGameObj.transform.position = transform.position;
        ////m_LinkGameObj.name = "복사식물_";

        // 방법 2번
        m_LinkGameObj = InGameSelectManager.GetInstance().ClonePlantResourceData();
        if( m_LinkGameObj != null )
        {
            m_LinkGameObj.transform.position = transform.position;
        }
        


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
