using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellEnergyIterator : MonoBehaviour
{
    public bool m_isTrigger = false;
    public GridMapController m_GripMapController;
    public int m_EnergyNum = 5;

    public void Start()
    {
        m_GripMapController = GetComponent<GridOBJ>().m_CellOBJManager.GetComponent<GridMapController>();
    }

    public void GetAroundAllGrid(int x, int y)
    {
        UseAddEnergyPack();

        GameObject obj;
        obj = m_GripMapController.GetLocationCell(x + 1, y);
        if (obj && obj.tag == "BloodPack" && obj.GetComponent<CellEnergyIterator>() && obj.GetComponent<CellEnergyIterator>().m_isTrigger == false)
        {
            obj.GetComponent<CellEnergyIterator>().GetAroundAllGrid(x + 1, y);
        }


        obj = m_GripMapController.GetLocationCell(x - 1, y);
        if (obj && obj.tag == "BloodPack" && obj.GetComponent<CellEnergyIterator>() && obj.GetComponent<CellEnergyIterator>().m_isTrigger == false)
        {
            obj.GetComponent<CellEnergyIterator>().GetAroundAllGrid(x - 1, y);
        }

        obj = m_GripMapController.GetLocationCell(x, y + 1);
        if (obj && obj.tag == "BloodPack" && obj.GetComponent<CellEnergyIterator>() && obj.GetComponent<CellEnergyIterator>().m_isTrigger == false)
        {
            obj.GetComponent<CellEnergyIterator>().GetAroundAllGrid(x, y + 1);
        }

        obj = m_GripMapController.GetLocationCell(x, y - 1);
        if (obj && obj.tag == "BloodPack" && obj.GetComponent<CellEnergyIterator>() && obj.GetComponent<CellEnergyIterator>().m_isTrigger == false)
        {
            obj.GetComponent<CellEnergyIterator>().GetAroundAllGrid(x, y - 1);
        }


        Destroy(gameObject);
    }

    public void UseAddEnergyPack()
    {
        m_isTrigger = true;
        GetComponent<GridOBJ>().m_Witcher.GetComponent<Witcher>().AddEnergy(m_EnergyNum);
    }
}
