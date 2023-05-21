using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : SingleTon_Mono<ResourceManager>
{
    [SerializeField]
    protected List<Sprite> m_SpriteList = new List<Sprite>();
    [SerializeField]
    protected Sprite m_BoomSprite = null;
    [SerializeField]
    protected List<Sprite> m_QuestList = new List<Sprite>();

    [SerializeField]
    protected List<Sprite> m_RightClickResouece = new List<Sprite>();

    public Sprite GetRightClick(E_RightClickType p_val)
    {
        return m_RightClickResouece[(int)p_val];
    }

    public Sprite GetMineCount(int p_count)
    {
        return m_SpriteList[p_count];
    }

    public Sprite GetBoomSprite()
    {
        return m_BoomSprite;
    }

    public Sprite GetQuestBlockSprite()
    {
        return m_QuestList[0];
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
