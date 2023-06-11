using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimation : MonoBehaviour
{

    [SerializeField]
    protected Animator m_LinkAnimator = null;

    private void Awake()
    {
        m_LinkAnimator = GetComponentInChildren<Animator>();
    }

    public void _On_SetAttack()
    {
        SetAttack();
    }

    public void SetAttack()
    {
        m_LinkAnimator.SetTrigger("Shoot");
    }

    public void SetIdle()
    {

    }

    public void SetDie()
    {

    }

    public void SetDamage()
    {

    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
