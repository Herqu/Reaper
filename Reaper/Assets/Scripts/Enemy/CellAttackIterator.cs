using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAttackIterator : MonoBehaviour
{

    [Header("当前的攻击激发对象和攻击时间")]
    public float m_AttackEffectTime;

    public GameObject m_AttackEffect = null;

    public GridMapController m_GripMapController;


    private void Start()
    {
        m_GripMapController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridMapController>();
    }


    public void GetIteratUpGrid(int iterateNUm, int range, float intervaltime, GameObject attackEffect)
    {
        if (range >= 1)
        {
            m_AttackEffectTime = Time.time + intervaltime * iterateNUm;
            m_AttackEffect = attackEffect;


            int x = (int)transform.position.x;
            int y = (int)transform.position.y + 1;

            GameObject obj= m_GripMapController.GetLocationCell(x, y);

            if (obj )
            {
                obj.GetComponent<CellAttackIterator>().GetIteratUpGrid(iterateNUm + 1, range - 1, intervaltime, attackEffect);

            }

        }
    }



    private void Update()
    {
        if (m_AttackEffect)
        {
            if (Time.time > m_AttackEffectTime)
            {
                //Debug.Log("GridCellAttackEffect");
                GameObject obj = Instantiate(m_AttackEffect, transform.position, Quaternion.identity, m_GripMapController.transform);
                obj.GetComponent<AttackEffect>().AttackInitialize(GetComponent<GridOBJ>(),m_GripMapController.GetComponent<AttackOBJController>());
                m_AttackEffect = null;
            }
        }
    }

}
