using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitcherWeapon : MonoBehaviour
{

    public int m_range = 1;
    public float m_IntervalTime = 0.8f;
    public GameObject m_attackEffectPrefab;

    public bool m_IsVertical = false;
    public bool m_IsHorizontal = false;
    public bool m_isZone = false;


    private void Awake()
    {
        m_attackEffectPrefab.GetComponent<AttackEffect>().m_Damage = 1;
    }


    public void CostEnergy()
    {
        m_CurrentEnergy -= m_EnergyCost;
    }


    [Header("能量部分")]
    public float m_CurrentEnergy = 100;
    public float m_FullEnergy = 100;
    public float m_EnergyRefillSpeed = 0.5f;
    public float m_EnergyCost = 15f;

    private void Update()
    {
        if(m_CurrentEnergy <= m_FullEnergy)
        {
            m_CurrentEnergy += m_EnergyRefillSpeed * Time.deltaTime;
        }
    }




    public bool isAttackAble()
    {
        if(m_CurrentEnergy <= m_EnergyCost)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public void AddRange()
    {
        m_range++;
    }


    public void AddDamage(int d)
    {
        m_attackEffectPrefab.GetComponent<AttackEffect>().m_Damage += d;
    }
}
