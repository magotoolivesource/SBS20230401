using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi_ConHead : Zombi
{
    //[SerializeField]
    //protected new string Name = "콘헤드좀비";

    public override string Name
    {
        get { return "콘헤드좀비"; }
    }

    public Sprite m_BaseSprite = null;
    protected bool m_ISChange = false;

    protected override void SetDamage(float p_dmg)
    {
        base.SetDamage(p_dmg);

        if (HP < 5
            && m_ISChange == false)
        {
            m_ISChange = true;
            GetComponent<SpriteRenderer>().sprite = m_BaseSprite;
        }
    }

    //protected void OnTriggerEnter2D(Collider2D collision)
    //{
        

    //    Plant_Bullet bullet = collision.GetComponent<Plant_Bullet>();

    //    if (bullet == null)
    //    {
    //        return;
    //    }

    //    HP -= (int)bullet.Damage;

    //    if( HP < 5 
    //        && m_ISChange == false)
    //    {
    //        m_ISChange = true;
    //        GetComponent<SpriteRenderer>().sprite = m_BaseSprite;
    //    }

    //    if (HP <= 0)
    //    {
    //        GameObject.Destroy(gameObject);
    //    }
    //}


}
