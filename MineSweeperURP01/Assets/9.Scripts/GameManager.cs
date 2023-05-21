using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon_Mono<GameManager>
{

    [Header("세팅용")]
    public int XSize = 4;
    public int YSize = 4;
    public int MineCount = 3;


    [Header("게임정보들")]
    public BlockElement m_CloneBlockElement = null;

    public Camera LinkCam = null;


    public bool[,] ISMineArr = new bool[4,4];
    public BlockElement[,] AllBlockElementArr = null;
    


    public bool ISSizeOver(int p_y, int p_x)
    {
        if (p_x < 0 || p_x >= XSize)
            return true;

        if (p_y < 0 || p_y >= YSize)
            return true;

        return false;
    }
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
    
    protected void SetMineSetting01()
    {
        for (int i = 0; i < MineCount; i++)
        {
            int randx = Random.Range(0, XSize); // 1
            int randy = Random.Range(0, YSize); // 1
            ISMineArr[randy, randx] = true;
        }
    }

    protected void SetMineSetting02()
    {
        int count = 0;
        int test_whilecount = 0;
        while (true)
        {
            ++test_whilecount;
            int randx = Random.Range(0, XSize); // 2
            int randy = Random.Range(0, YSize); // 1
            if( ISMineArr[randy, randx] == false )
            {
                ISMineArr[randy, randx] = true;
                count++;
            }

            if (count >= MineCount)
                break;
        }

        Debug.Log($"총 while 갯수 :{test_whilecount} ");
    }

    protected void SetMineSetting03()
    {
        List<int> allgridindex = new List<int>();
        for (int i = 0; i < XSize * YSize; i++)
        {
            allgridindex.Add(i);
        }

        for (int i = 0; i < MineCount; i++)
        {
            int randomidnex = Random.Range(0, allgridindex.Count);
            int val = allgridindex[randomidnex];

            int x = val % XSize;
            int y = val / XSize;
            ISMineArr[y, x] = true;

            allgridindex.RemoveAt(randomidnex);
        }
    }

    protected void InitMineSeeting()
    {
        ISMineArr = new bool[YSize, XSize];
        
        if ( false )
        {
            // 테스트 코드
            ISMineArr[2, 2] = true;
        }
        else
        {
            //SetMineSetting01();
            //SetMineSetting02();
            SetMineSetting03();

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

        CenterCameraPos();
    }

    // regex

    void CenterCameraPos()
    {
        float offsetx = (float)XSize * 0.5f;
        float offsety = (float)YSize * 0.5f;

        LinkCam.transform.position = new Vector3(offsetx - 0.5f
                                    , offsety - 0.5f
                                    , LinkCam.transform.position.z);
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
                //cloneobj.m_ParentManager = this;

                AllBlockElementArr[y, x] = cloneobj;

            }
        }
    }

    public Vector3 MousePos = new Vector3();
    public Vector3 Wpos = new Vector3();
    public SpriteRenderer m_TempRender = null;
    void UpdateClick()
    {
        // 오른버턴 누름
        if( Input.GetMouseButtonDown(1) )
        {
            MousePos = Input.mousePosition;
            Ray ray = LinkCam.ScreenPointToRay(MousePos);

            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, 999f))
            {
                BlockElement element = hitinfo.transform.GetComponent<BlockElement>();
                if( element != null )
                {
                    element.OnLeftMouseDown();
                }
            }

        }



        //// 클릭 방법1
        ////return;

        //if( false
        //    && Input.GetMouseButtonDown(0) )
        //{
        //    MousePos = Input.mousePosition;
        //    Ray ray = LinkCam.ScreenPointToRay(MousePos);

        //    RaycastHit hitinfo;
        //    if( Physics.Raycast(ray, out hitinfo, 999f) )
        //    {
        //        //Debug.Log($"레이로 부딪힌값 : {hitinfo.transform.gameObject.name}");

        //        BlockElement element = hitinfo.transform.GetComponent<BlockElement>();
        //        if( element != null)
        //        {
        //            Debug.Log($"레이로 부딪힌값 : {element.GridPos.x}, {element.GridPos.y}");
        //        }
        //        else
        //        {
        //            Debug.Log($"잘못 눌렸습니다. ");
        //        }

        //    }

        //}

    }




    // 재귀함수
    public void OpenAroundMine(int p_posx, int p_posy)
    {
        if (ISSizeOver(p_posx, p_posy))
            return;

        int yy = p_posy;
        int xx = p_posx;


        // 오른쪽
        if ( !ISSizeOver(xx + 1, yy) )
        {
            if ( !AllBlockElementArr[yy, xx + 1].ISOpen )
            {
                int minecount = AllBlockElementArr[yy, xx + 1].SetMouseClick();

                if (minecount == 0)
                {
                    OpenAroundMine(xx + 1, yy);
                }
            }
        }

        // 왼쪽
        if (!ISSizeOver(xx - 1, yy))
        {
            if (!AllBlockElementArr[yy, xx - 1].ISOpen)
            {
                int minecount = AllBlockElementArr[yy, xx - 1].SetMouseClick();

                if (minecount == 0)
                {
                    OpenAroundMine(xx - 1, yy);
                }
            }
                
        }


        // 위쪽
        if (!ISSizeOver(xx, yy + 1))
        {
            if (!AllBlockElementArr[yy + 1, xx].ISOpen)
            {
                int minecount = AllBlockElementArr[yy + 1, xx].SetMouseClick();

                if (minecount == 0)
                {
                    OpenAroundMine(xx, yy + 1);
                }
            }
        }


        // 아래쪽
        if (!ISSizeOver(xx, yy - 1))
        {
            if (!AllBlockElementArr[yy - 1, xx].ISOpen)
            {
                int minecount = AllBlockElementArr[yy - 1, xx].SetMouseClick();
                if (minecount == 0)
                {
                    OpenAroundMine(xx, yy - 1);
                }
            }
        }

    }

    public void OpenCrossMine( Vector2Int p_centerpos )
    {
        int yy = p_centerpos.y;
        int xx = p_centerpos.x;


        // 재귀함수 라는 방식으로 처리해야지 됩니다.


        // 오른쪽
        for (int x = p_centerpos.x + 1; x < XSize; x++)
        {
            //int minecount = GetArounMineCount(x, yy);
            int minecount = AllBlockElementArr[yy, x].SetMouseClick();

            if ( minecount > 0)
            {
                break;
            }
        }

        // 왼쪽
        for (int x = p_centerpos.x - 1; x >= 0; x--)
        {
            int minecount = AllBlockElementArr[yy, x].SetMouseClick();

            if (minecount > 0)
            {
                break;
            }
        }

        // 위 
        for (int y = yy + 1; y < YSize; y++)
        {
            int minecount = AllBlockElementArr[y, xx].SetMouseClick();

            if (minecount > 0)
            {
                break;
            }
        }

        for (int y = yy - 1; y >= 0; y--)
        {
            if (AllBlockElementArr[y, xx].SetMouseClick() > 0)
            {
                break;
            }
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
