//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public enum E_ATTACKTYPE
//{
//    Land =  0x0001,   // 0
//    Sky =   0x0002,    // 1
//    Build = 0x0004,  // 2
//    All = Land | Sky | Build,
//}
//public class Actor
//{
//    public E_ATTACKTYPE type = E_ATTACKTYPE.All;
//    public int HP = 10;
//    public virtual void Attack();
//    public virtual void Move();
//}

//public class Human : Actor
//{

//}

//public class Marin : Human
//{
    
//    public override void Attack();
//}

//public class FireBet : Human
//{
//    public E_ATTACKTYPE type = E_ATTACKTYPE.Land;
//    public override void Attack();
//}

//public class Medic : Human
//{
//    public E_ATTACKTYPE type = E_ATTACKTYPE.Land;
//    public override void Attack()
//    {
//        Heal();
//    }
//    public void Heal();

//}

//public class HeavyVerchile : Actor
//{

//}

//public class Tank : HeavyVerchile
//{

//}

//public class Race : HeavyVerchile
//{
//    public override void Move();
//}

//// 컴포넌트 방식

//public class Baseactor
//{
//    public HPStat stat;
//    public AttackCom attackcom;
//}

//public class Marine : Baseactor
//{
//    public HPStat stat;
//    public MoveLand land;
//    //public AllTypAttack attack;
//    void init()
//    {
//        attackcom = new AllTypAttack();
//    }
//}

//public class Firebet : Baseactor
//{
    
//    public MoveLand land;
//    public LandAttack attack;
//}


//public class HPStat
//{
//    public int HP = 10;
//}

//public class MoveLand
//{

//}
//public class MoveSky
//{

//}

//public class AttackCom
//{

//}

//public class LandAttack: AttackCom
//{

//}

//public class SkyAttack : AttackCom
//{

//}

//public class AllTypAttack : AttackCom
//{

//}



//public class TestSC : MonoBehaviour
//{
//    void Start()
//    {
        
//    }
    
//    void Update()
//    {
        
//    }
//}
