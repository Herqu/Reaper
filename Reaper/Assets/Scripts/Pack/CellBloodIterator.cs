using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBloodIterator : MonoBehaviour
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
        UseAddBloodPack();

        GameObject obj;
        obj = m_GripMapController.GetLocationCell(x + 1, y);
        if (obj && obj.tag == "BloodPack" && obj.GetComponent<CellBloodIterator>() && obj.GetComponent<CellBloodIterator>().m_isTrigger == false)
        {
            UseAddBloodPack();
            obj.GetComponent<CellBloodIterator>().GetAroundAllGrid(x + 1, y);
        }


        obj = m_GripMapController.GetLocationCell(x - 1, y);
        if (obj && obj.tag == "BloodPack" && obj.GetComponent<CellBloodIterator>() && obj.GetComponent<CellBloodIterator>().m_isTrigger == false)
        {
            UseAddBloodPack();
            obj.GetComponent<CellBloodIterator>().GetAroundAllGrid(x - 1, y);
        }

        obj = m_GripMapController.GetLocationCell(x, y + 1);
        if (obj && obj.tag == "BloodPack" && obj.GetComponent<CellBloodIterator>() && obj.GetComponent<CellBloodIterator>().m_isTrigger == false)
        {
            UseAddBloodPack();
            obj.GetComponent<CellBloodIterator>().GetAroundAllGrid(x, y + 1);
        }

        obj = m_GripMapController.GetLocationCell(x, y - 1);
        if (obj && obj.tag == "BloodPack" && obj.GetComponent<CellBloodIterator>() && obj.GetComponent<CellBloodIterator>().m_isTrigger == false)
        {
            UseAddBloodPack();
            obj.GetComponent<CellBloodIterator>().GetAroundAllGrid(x, y - 1);
        }


        Destroy(gameObject);
    }

    public void UseAddBloodPack()
    {
        m_isTrigger = true;
        GetComponent<GridOBJ>().m_Witcher.GetComponent<Witcher>().AddBlood(m_bloodPackNUM);
    }
}
