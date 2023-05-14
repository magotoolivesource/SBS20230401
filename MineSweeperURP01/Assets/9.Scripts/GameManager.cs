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
    
    
    protected void InitMineSeeting()
    {
        ISMineArr = new bool[YSize, XSize];
        
        if ( true )
        {
            // �׽�Ʈ �ڵ�
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
                AllBlockElementArr[y, x] = cloneobj;

            }
        }
    }

    public Vector3 MousePos = new Vector3();
    public Vector3 Wpos = new Vector3();
    public SpriteRenderer m_TempRender = null;
    void UpdateClick()
    {
        // ���1
        //return;

        if( Input.GetMouseButtonDown(0) )
        {
            MousePos = Input.mousePosition;
            Ray ray = LinkCam.ScreenPointToRay(MousePos);

            RaycastHit hitinfo;
            if( Physics.Raycast(ray, out hitinfo, 999f) )
            {
                //Debug.Log($"���̷� �ε����� : {hitinfo.transform.gameObject.name}");

                BlockElement element = hitinfo.transform.GetComponent<BlockElement>();
                if( element != null)
                {
                    Debug.Log($"���̷� �ε����� : {element.GridPos.x}, {element.GridPos.y}");
                }
                else
                {
                    Debug.Log($"�߸� ���Ƚ��ϴ�. ");
                }
                
            }
            
        }

        //if( Input.GetMouseButtonDown(0) )
        //{
        //    // ���콺 ��ġ
        //    MousePos = Input.mousePosition;

        //    // ���� ��ǥ
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
