using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapController : MonoBehaviour
{
    public GameObject[,] m_gridMap ;
    public GameObject[,] m_CellMap;


    private void Awake()
    {
        GameObject[] allCell= GameObject.FindGameObjectsWithTag("GridCell");
        m_gridMap = new GameObject[GetComponent<GameManager>().m_xLength, GetComponent<GameManager>().m_yLength];
        m_CellMap = new GameObject[GetComponent<GameManager>().m_xLength, GetComponent<GameManager>().m_yLength];

        foreach (GameObject obj in allCell)
        {
            int x = (int)obj.transform.position.x;
            int y = (int)obj.transform.position.y;

            m_gridMap[x, y] = obj;
        }
        ///这里对m_gridmap做一个操作。
        ///
        GetComponent<CellOBJManager>().PutCellOBJ(m_CellMap);



    }


    public GameObject GetLocationCell(int x, int y)
    {
        GameObject obj = null;

        if (x>=0&& x < GetComponent<GameManager>().m_xLength)
        {
            if(y>= 0 && y < GetComponent<GameManager>().m_yLength)
            {
                
                obj = m_CellMap[x, y];

                return obj;
            }

        }


        return obj;
    }



    
}
