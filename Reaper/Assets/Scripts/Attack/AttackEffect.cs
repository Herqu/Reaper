using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{

    public GridOBJ m_gridObj;
    public AttackOBJController m_AttackOBJCOntroller;
    public float m_LastTime = 0.5f;

    public int m_Damage = 1;

    public void AttackInitialize( GridOBJ obj, AttackOBJController aoc)
    {
        m_gridObj= obj;
        m_AttackOBJCOntroller = aoc;
        m_AttackOBJCOntroller.AddAttackOBJ(gameObject);
        m_LastTime = Time.time + m_LastTime;

        if (m_gridObj != null && m_gridObj.tag == "Enemy")
        {
            m_gridObj.GetComponent<SpiderCondition>().Hurt(m_Damage);

        }
    }



    private void Update()
    {
        if (Time.time > m_LastTime)
        {

            Destroy(gameObject);

        }
    }

    private void OnDestroy()
    {
            m_AttackOBJCOntroller.RemoveAttackOBJ(gameObject);

    }
}
