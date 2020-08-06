using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witcher : MonoBehaviour
{

    public float m_LeftBlood = 100;
    public float m_fullBlood = 500;
    public GameObject m_LosePanel;

    private void Awake()
    {
        m_LeftBlood = m_fullBlood;
    }

    public void GetHurt(float damage)
    {
        m_LeftBlood -= damage;
    }


    private void Update()
    {
        if(m_LeftBlood <= 0)
        {
            Debug.Log("YOULOSE");
            m_LosePanel.SetActive(true);
        }
    }

    public void AddBlood(int v)
    {
        m_LeftBlood += v;
        if(m_LeftBlood >= m_fullBlood)
        {
            m_LeftBlood = m_fullBlood;
        }
    }



    public void AddEnergy(int v)
    {
        GetComponent<WitcherWeapon>().m_CurrentEnergy += v;
        if(GetComponent<WitcherWeapon>().m_CurrentEnergy >= GetComponent<WitcherWeapon>().m_FullEnergy)
        {
            GetComponent<WitcherWeapon>().m_CurrentEnergy = GetComponent<WitcherWeapon>().m_FullEnergy;
        }
    }
}
