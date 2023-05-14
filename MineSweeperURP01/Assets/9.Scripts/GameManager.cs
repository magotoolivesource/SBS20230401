using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BlockElement m_CloneBlockElement = null;

    public int XSize = 4;
    public int YSize = 4;

    public Camera LinkCam = null;
    public bool[,] ISMineArr = new bool[4,4];
    public BlockElement[,] AllBlockElementArr = null;
    


    public bool ISMine(int p_y, int p_x )
    {
        if (p_x < 0 || p_x >= XSize)
            return false;

        if (p_y < 0 || p_y >= YSize)
            return false;

        return ISMineArr[p_y, p_x];
    }

    public int GetArounMineCount( int p_x, int p_y )
    {
        int outmine = 0;

        // 상단 3개
        if (ISMine(p_y + 1, p_x - 1) == true) ++outmine;
        if (ISMine(p_y + 1, p_x - 0) == true) ++outmine;
        if (ISMine(p_y + 1, p_x + 1) == true) ++outmine;

        // 가운데 3개
        if (ISMine(p_y + 0, p_x - 1) == true) ++outmine;
        //if (ISMineArr[p_y + 1, p_x - 0] == true) ++outmine;
        if (ISMine(p_y + 0, p_x + 1) == true) ++outmine;


        if (ISMine(p_y - 1, p_x - 1) == true) ++outmine;
        if (ISMine(p_y - 1, p_x - 0) == true) ++outmine;
        if (ISMine(p_y - 1, p_x + 1) == true) ++outmine;

        return outmine;
    }
    
    protected void InitMineSeeting()
    {
        ISMineArr = new bool[YSize, XSize];
        
        if ( true )
        {
            // 테스트 코드
            ISMineArr[1, 2] = true;
        }



        for (int y = 0; y < YSize; y++)
        {
            for (int x = 0; x < XSize; x++)
            {
                AllBlockElementArr[y, x].SetMine( ISMineArr[y, x] );
            }

        }


    }

    private void Awake()
    {

        CreateMine();

        InitMineSeeting();
    }

    void CreateMine()
    {
        AllBlockElementArr = new BlockElement[YSize, XSize];
        for (int y = 0; y < YSize; y++)
        {
            for (int x = 0; x < XSize; x++)
            {
                Vector3 pos = new Vector3(x, YSize - 1 - y, 0);
                BlockElement cloneobj =  GameObject.Instantiate(m_CloneBlockElement
                    , pos
                    , Quaternion.identity );

                cloneobj.name = $"Mine_[{x},{y}]";
                cloneobj.SetGridPos(x, y);
                cloneobj.m_ParentManager = this;

                AllBlockElementArr[y, x] = cloneobj;

            }
        }
    }

    public Vector3 MousePos = new Vector3();
    public Vector3 Wpos = new Vector3();
    public SpriteRenderer m_TempRender = null;
    void UpdateClick()
    {
        // 클릭 방법1
        return;

        if( Input.GetMouseButtonDown(0) )
        {
            MousePos = Input.mousePosition;
            Ray ray = LinkCam.ScreenPointToRay(MousePos);

            RaycastHit hitinfo;
            if( Physics.Raycast(ray, out hitinfo, 999f) )
            {
                //Debug.Log($"레이로 부딪힌값 : {hitinfo.transform.gameObject.name}");

                BlockElement element = hitinfo.transform.GetComponent<BlockElement>();
                if( element != null)
                {
                    Debug.Log($"레이로 부딪힌값 : {element.GridPos.x}, {element.GridPos.y}");
                }
                else
                {
                    Debug.Log($"잘못 눌렸습니다. ");
                }
                
            }
            
        }

        //if( Input.GetMouseButtonDown(0) )
        //{
        //    // 마우스 위치
        //    MousePos = Input.mousePosition;

        //    // 월드 좌표
        //    Camera cam = LinkCam;
        //    Wpos = cam.ScreenToWorldPoint(MousePos);


        //    Wpos.z = 0f;
        //    m_TempRender.transform.position = Wpos;
        //}

    }


    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateClick();

    }
}
