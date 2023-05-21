using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_RightClickType : int
{
    Default = 0,
    E_Flag = 1,
    E_Question = 2,

}


public class BlockElement : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int m_GridPos;
    [SerializeField]
    protected bool m_ISMine;


    public Vector2Int GridPos
    {
        get { return m_GridPos; }
        set { m_GridPos = value; }
    }

    public Vector2Int GetGridPos()
    {
        return m_GridPos;
    }
    public void SetGridPos(int x, int y)
    {
        m_GridPos.x = x;
        m_GridPos.y = y;
    }



    public void SetMine(bool p_ismine)
    {
        m_ISMine = p_ismine;
    }

    private void OnDrawGizmos()
    {
        // µð¹ö±ë¿ë
        if( m_ISMine )
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(this.transform.position, new Vector3(0.5f, 0.5f, 0.5f));
        }
    }

    public GameManager m_ParentManager = null;
    public bool ISOpen = false;

    public int SetMouseClick()
    {
        //int minecount = m_ParentManager.GetArounMineCount(this.GridPos.x, this.GridPos.y);
        //Debug.Log($"ÁÖº¯ Áö·Ú°¹¼ö´Â : {minecount}");

        int minecount = GameManager.GetInstance().GetArounMineCount(this.GridPos.x, this.GridPos.y);
        Debug.Log($"ÁÖº¯ Áö·Ú°¹¼ö´Â : {minecount}");

        Sprite img = ResourceManager.Instance.GetMineCount(minecount);
        GetComponent<SpriteRenderer>().sprite = img;
        ISOpen = true;

        return minecount;
    }

    public E_RightClickType RightClickCount = E_RightClickType.Default;
    public void OnLeftMouseDown()
    {
        if (ISOpen)
            return;

        RightClickCount = (E_RightClickType)(((int)RightClickCount + 1) % 3);
        GetComponent<SpriteRenderer>().sprite = ResourceManager.Instance.GetRightClick(RightClickCount);
    }

    private void OnMouseDown()
    {
        Debug.Log($"·¹ÀÌ·Î ºÎµúÈù°ª : {this.GridPos.x}, {this.GridPos.y}");
        //Debug.Log("ºí·°À» Å¬¸¯ÇßÀ½");

        if( m_ISMine )
        {
            ISOpen = true;
            GetComponent<SpriteRenderer>().sprite = ResourceManager.Instance.GetBoomSprite();
            return;
        }

        int minecount = SetMouseClick();

        if ( minecount == 0 )
        {
            StartCoroutine(GameManager.GetInstance().OpenAroundMineCoroutinue(this.GridPos.x, this.GridPos.y));
            ;
            
        }

    }



    private void Awake()
    {
        //m_ParentManager = GameObject.FindObjectOfType<GameManager>();

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
