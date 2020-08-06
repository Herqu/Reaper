using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRangeIterator : MonoBehaviour
{
    public bool m_isTrigger = false;
    public GridMapController m_GripMapController;
    public int m_bloodPackNUM = 5;

    public void Start()
    {
        m_GripMapController = GetComponent<GridOBJ>().m_CellOBJManager.GetComponent<GridMapController>();
    }

    public void GetAroundAllGrid(int x, int y)
    {
        UseAddRangePack();

        GameObject obj;
        obj = m_GripMapController.GetLocationCell(x + 1, y);
        if (obj && obj.GetComponent<CellRangeIterator>() && obj.GetComponent<CellRangeIterator>().m_isTrigger == false)
        {
            obj.GetComponent<CellRangeIterator>().GetAroundAllGrid(x + 1, y);
        }


        obj = m_GripMapController.GetLocationCell(x - 1, y);
        if (obj &&obj.GetComponent<CellRangeIterator>() && obj.GetComponent<CellRangeIterator>().m_isTrigger == false)
        {
            obj.GetComponent<CellRangeIterator>().GetAroundAllGrid(x - 1, y);
        }

        obj = m_GripMapController.GetLocationCell(x, y + 1);
        if (obj &&obj.GetComponent<CellRangeIterator>() && obj.GetComponent<CellRangeIterator>().m_isTrigger == false)
        {
            obj.GetComponent<CellRangeIterator>().GetAroundAllGrid(x, y + 1);
        }

        obj = m_GripMapController.GetLocationCell(x, y - 1);
        if (obj && obj.GetComponent<CellRangeIterator>() && obj.GetComponent<CellRangeIterator>().m_isTrigger == false)
        {
            obj.GetComponent<CellRangeIterator>().GetAroundAllGrid(x, y - 1);
        }


        Destroy(gameObject);
    }

    public void UseAddRangePack()
    {
        m_isTrigger = true;
        GetComponent<GridOBJ>().m_Witcher.GetComponent<WitcherWeapon>().AddRange();
        GetComponent<GridOBJ>().m_CellOBJManager.GetComponent<CharaUIManager>().AddNewUI(GetComponent<SpriteRenderer>().sprite);
    }
}
