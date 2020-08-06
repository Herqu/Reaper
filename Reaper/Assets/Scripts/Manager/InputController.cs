using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputController : MonoBehaviour
{
    public Camera m_Camera;
    public GameObject m_Witcher;
    public WitcherWeapon m_WitcherWeapon;

    private void Awake()
    {
        m_Camera = Camera.main;
        m_Witcher= GameObject.FindGameObjectWithTag("Player");
        m_WitcherWeapon = m_Witcher.GetComponent<WitcherWeapon>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ry2 = Physics2D.Raycast(m_Camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (ry2.collider != null)
            {
                //Debug.Log(ry2.collider.name);
                //Instantiate(m_TestAttackOBJ, ry2.transform.position, Quaternion.identity);

                //ry2.collider.GetComponent<CellOBJAttackEffect>().GetIteratUpGrid(1,2,0.2f,m_attackEffectPrefab);

                switch (ry2.collider.tag)
                {
                    case "Enemy":
                        if (m_WitcherWeapon.m_IsVertical)
                        {
                            if (m_WitcherWeapon.isAttackAble())
                            {
                                ry2.collider.GetComponent<CellAttackIterator>().GetIteratUpGrid(1, m_WitcherWeapon.m_range, m_WitcherWeapon.m_IntervalTime, m_WitcherWeapon.m_attackEffectPrefab);
                                m_WitcherWeapon.CostEnergy();

                            }

                        }

                        if (m_WitcherWeapon.m_IsHorizontal)
                        {

                        }

                        if (m_WitcherWeapon.m_isZone)
                        {

                        }
                        break;
                    case "BloodPack":
                        //m_Witcher.GetComponent<Witcher>().AddBlood(50);

                        if (ry2.collider.GetComponent<CellBloodIterator>())
                        {
                            ry2.collider.GetComponent<CellBloodIterator>().GetAroundAllGrid((int)ry2.collider.transform.position.x, (int)ry2.collider.transform.position.y);
                        }
                        else if (ry2.collider.GetComponent<CellEnergyIterator>())
                        {
                            ry2.collider.GetComponent<CellEnergyIterator>().GetAroundAllGrid((int)ry2.collider.transform.position.x, (int)ry2.collider.transform.position.y);

                        }
                        else if (ry2.collider.GetComponent<CellRangeIterator>())
                        {
                            ry2.collider.GetComponent<CellRangeIterator>().GetAroundAllGrid((int)ry2.collider.transform.position.x, (int)ry2.collider.transform.position.y);

                        }
                        else if (ry2.collider.GetComponent<CellDamageIterator>())
                        {
                            ry2.collider.GetComponent<CellDamageIterator>().GetAroundAllGrid((int)ry2.collider.transform.position.x, (int)ry2.collider.transform.position.y);

                        }
                        break;

                }




            }



        }
    }


}
