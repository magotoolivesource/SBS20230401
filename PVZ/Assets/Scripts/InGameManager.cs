using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{


    public int WSize = 8;
    public int HSize = 5;

    public Vector2 BlockSize = new Vector2(1.3f, 1.3f);
    public BGSprite m_CloneBGSprite = null;

    public BGSprite[,] m_AllBGSpitre = null;

    void CreateBGClickSprite()
    {
        m_AllBGSpitre = new BGSprite[HSize, WSize];
        for (int y = 0; y < HSize; y++)
        {
            for (int x = 0; x < WSize; x++)
            {
                BGSprite cloneSprite = GameObject.Instantiate(m_CloneBGSprite, this.transform);
                cloneSprite.transform.localPosition = new Vector3(BlockSize.x * x, BlockSize.y * y, 0f);
                cloneSprite.name = $"CloneBG_[{x},{y}]";
                
                m_AllBGSpitre[y, x] = cloneSprite;
            }
        }

    }

    void Start()
    {
        CreateBGClickSprite();
    }


    void Update()
    {
        
    }
}
