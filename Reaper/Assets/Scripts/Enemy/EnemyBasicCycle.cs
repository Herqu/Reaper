using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicCycle : MonoBehaviour
{
    public void Vertigo()
    {

    }

    public void Interrupt()
    {
        GetComponent<SpiderAttack>().m_NextAttackTime = Time.time + GetComponent<SpiderAttack>().m_AttackTImeInterval;

    }
}
