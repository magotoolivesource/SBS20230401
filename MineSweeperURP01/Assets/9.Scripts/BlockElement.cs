using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void OnMouseDown()
    {
        Debug.Log($"·¹ÀÌ·Î ºÎµúÈù°ª : {this.GridPos.x}, {this.GridPos.y}");
        //Debug.Log("ºí·°À» Å¬¸¯ÇßÀ½");


        int minecount = m_ParentManager.GetArounMineCount(this.GridPos.x, this.GridPos.y);
        Debug.Log($"ÁÖº¯ Áö·Ú°¹¼ö´Â : {minecount}");

    }





    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
