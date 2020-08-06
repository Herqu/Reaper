using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    public float m_SpiderDamage = 2;

    public void Attack(Witcher w)
    {
        w.GetHurt(2);
    }



    private void Awake()
    {
        m_NextAttackTime = Time.time + Random.Range(m_AttackTImeInterval / 2, m_AttackTImeInterval);

    }

    [Header("时间部分")]

    public float m_AttackTImeInterval;
    public float m_NextAttackTime;
    public float m_LeftTimeRatio = 0;
    private void Update()
    {
        if (m_NextAttackTime <= Time.time)
        {
            m_NextAttackTime = Time.time + m_AttackTImeInterval;
            GetComponent<GridOBJ>().m_CellOBJManager.GetComponent<EnemyUIController>().NewIntention(transform.position,m_SpiderDamage);
            GetComponent<SpiderAttack>().Attack(GetComponent<GridOBJ>().m_Witcher.GetComponent<Witcher>());
        }



        ///这里做剩余时间比例的计算。
        ///
        m_LeftTimeRatio = (m_NextAttackTime - Time.time) / m_AttackTImeInterval;
    }
}
