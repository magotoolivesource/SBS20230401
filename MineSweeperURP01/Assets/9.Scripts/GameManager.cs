using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpriteRenderer m_LinkSpriteRender = null;

    public int XSize = 4;
    public int YSize = 4;

    public Camera LinkCam = null;
    public bool[,] ISMineArr = new bool[4,4];
    
    
    protected void InitMineSeeting()
    {
        ISMineArr = new bool[YSize, XSize];

        if( true )
        {
            // 테스트 코드
            ISMineArr[1, 2] = true;
        }
    }

    private void Awake()
    {

        CreateMine();

        
    }

    void CreateMine()
    {
        for (int y = 0; y < YSize; y++)
        {
            for (int x = 0; x < XSize; x++)
            {
                Vector3 pos = new Vector3(x, YSize - 1 - y, 0);
                SpriteRenderer cloneobj =  GameObject.Instantiate(m_LinkSpriteRender
                    , pos
                    , Quaternion.identity );

                cloneobj.name = $"Mine_[{x},{y}]";

                //m_ArrSprite.Add(sprite);
            }
        }
    }

    public Vector3 MousePos = new Vector3();
    public Vector3 Wpos = new Vector3();
    public SpriteRenderer m_TempRender = null;
    void UpdateClick()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            // 마우스 위치
            MousePos = Input.mousePosition;

            // 월드 좌표
            Camera cam = LinkCam;
            Wpos = cam.ScreenToWorldPoint(MousePos);

            Wpos.z = 0f;
            m_TempRender.transform.position = Wpos;
        }

    }


    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateClick();

    }
}
