using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownManager : MonoBehaviour
{
    public Rect RangeSize = new Rect();




    [ContextMenu("[박스사이즈 지정하기]")]
    private void _Editor_AdjustRectBox()
    {
        BoxCollider2D boxcollider = gameObject.GetComponentInChildren<BoxCollider2D>(true);
        
        if( boxcollider.gameObject.activeInHierarchy )
        {
            // 바운드 박스방식
            RangeSize = new Rect(boxcollider.bounds.min, boxcollider.bounds.extents * 2f);
        }
        else
        {
            // 오프셋 방식
            Vector2 pos = boxcollider.transform.position;
            Vector2 centerpos = boxcollider.offset + pos;
            Vector2 minpos = centerpos - (boxcollider.size * 0.5f);

            RangeSize = new Rect(minpos, boxcollider.size );
        }
        
        

        boxcollider.gameObject.SetActive(false);
    }



    [SerializeField]
    protected FallDownDoTween m_CloneTween = null;
    public void _On_CreateFallDownSun()
    {
        CreateFallDownSun();
    }

    public void CreateFallDownSun()
    {
        FallDownDoTween clonecom = GameObject.Instantiate(m_CloneTween);
        clonecom.InitSetting(RangeSize);

    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
