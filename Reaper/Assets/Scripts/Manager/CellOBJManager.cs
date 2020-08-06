using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using System;

public class CellOBJManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> m_allKindOfGridOBJ1 = new List<GameObject>();
    public List<GameObject> m_allKindOfTreasureGridOBJ2 = new List<GameObject>();
    public List<GameObject> m_allKindOfTreasureGridOBJ3 = new List<GameObject>();

    [Range(0, 1f)]
    public float m_TreasureRatio1 = 0.01f;
    [Range(0, 1f)]
    public float m_TreasureRatio2 = 0.01f;

    public void PutCellOBJ(GameObject[,] cm)
    {
        foreach(GameObject grid in GetComponent<GridMapController>().m_gridMap)
        {
            GameObject cellOBJ = Instantiate(GetNewOBJ(), grid.transform.position, quaternion.identity, grid.transform);
            cm[(int)grid.transform.position.x, (int)grid.transform.position.y] = cellOBJ;
            cellOBJ.GetComponent<GridOBJ>().Initialize(this);
        }
    }



    public GameObject GetNewOBJ()
    {
        if (m_allKindOfGridOBJ1.Count == 0|| m_allKindOfTreasureGridOBJ2.Count == 0)
        {
            Debug.LogError("有错。因为灭有预制的cell");
            return null;
        }

        int i_1 = Random.Range(1, m_allKindOfGridOBJ1.Count+1)-1;
        int i_2 = Random.Range(1, m_allKindOfTreasureGridOBJ2.Count+1)-1;
        int i_3 = Random.Range(1, m_allKindOfTreasureGridOBJ3.Count+1)-1;

        float ratio = Random.Range(0f, 1f);
        if (ratio <= m_TreasureRatio2)
        {
            return m_allKindOfTreasureGridOBJ3[i_3];
        }
        else if(ratio >= m_TreasureRatio2&& ratio <= m_TreasureRatio1)
        {
            return m_allKindOfTreasureGridOBJ2[i_2];

        }
        else
        {
            return m_allKindOfGridOBJ1[i_1];
        }

    }


    public void CheckAndRedistribute()
    {
        for (int x = 0; x < GetComponent<GameManager>().m_xLength; x++)
        {
            for (int y = 0; y < GetComponent<GameManager>().m_yLength; y++)
            {
                //GridCell gc = GetComponent<GridMapController>().m_gridMap[x, y].GetComponent<GridCell>();
                //if (!gc.m_IsFilledOBJ)
                //{

                //    gc.m_CurrentObj = Instantiate(GetNewOBJ(), gc.transform.position, Quaternion.identity, gc.transform);
                //    gc.m_CurrentObj.GetComponent<GridOBJ>().m_CurrentGridCell = gc;
                //}
            }

        }
    }


    [Header("NewCellPutPosition")]
    public Vector2 m_newPositionOffset = Vector2.up;


    public void RemoveCell(int x,int y)
    {



        for(int t= y; t< GetComponent<GameManager>().m_yLength;t++)
        {
            if(t< GetComponent<GameManager>().m_yLength-1)
            {
                GetComponent<GridMapController>().m_CellMap[x, t] = GetComponent<GridMapController>().m_CellMap[x, t + 1];
                GetComponent<GridMapController>().m_CellMap[x, t].transform.SetParent(GetComponent<GridMapController>().m_gridMap[x,t].transform);
                
            }
            else
            {
                GameObject newobj = Instantiate(GetNewOBJ(), (Vector2)GetComponent<GridMapController>().m_gridMap[x, t].transform.position + m_newPositionOffset, quaternion.identity,GetComponent<GridMapController>().m_gridMap[x,t].transform);
                newobj.GetComponent<GridOBJ>().Initialize(this);
                GetComponent<GridMapController>().m_CellMap[x, t] = newobj;

            }
        }
    }



    public List<int2> m_ListLocation = new List<int2>();
    public void RegistRemovedCell(int x,int y)
    {
        m_ListLocation.Add(new int2(x, y));
    }


    public void RemoveRegistCell()
    {
        int x;
        int y;


        for(x= 0; x< GetComponent<GameManager>().m_xLength; x++)
        {
            for (y= 0; y< GetComponent<GameManager>().m_yLength; y++)
            {
                if (!GetComponent<GridMapController>().m_CellMap[x,y])
                {

                    GetComponent<GridMapController>().m_CellMap[x, y] = ReturnUpCellorInstanciateNewCell(x, y);
                    GetComponent<GridMapController>().m_CellMap[x, y].transform.SetParent(GetComponent<GridMapController>().m_gridMap[x, y].transform);

                }
            }
        }
    }

    public GameObject ReturnUpCellorInstanciateNewCell(int x, int y)
    {

        GameObject obj ;
        if (y == GetComponent<GameManager>().m_yLength - 1)
        {
            GameObject newobj = Instantiate(GetNewOBJ(), (Vector2)GetComponent<GridMapController>().m_gridMap[x,y].transform.position + m_newPositionOffset, quaternion.identity, GetComponent<GridMapController>().m_gridMap[x,y].transform);
            newobj.GetComponent<GridOBJ>().Initialize(this);
            obj = newobj;
        }
        else
        {
            if (GetComponent<GridMapController>().m_CellMap[x, y + 1])
            {
                obj = GetComponent<GridMapController>().m_CellMap[x, y + 1];
                GetComponent<GridMapController>().m_CellMap[x, y + 1] = null;
            }
            else
            {
                obj = ReturnUpCellorInstanciateNewCell(x, y + 1);
            }

        }




        return obj;
    }
}
