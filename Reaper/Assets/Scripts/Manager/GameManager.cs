using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject m_gridCellPrefab;
    public Transform m_GridMapTransform;

    public int m_xLength;
    public int m_yLength;
    public List<GameObject> m_allCell ;

    public Vector2 m_offset = new Vector2(1, 1);


    [Header("摄像机和偏移")]
    public Camera m_camera;
    public Vector3 m_CameraOffset;



    public void CreateGridMap()
    {
        m_camera = Camera.main;
        Vector3 cameraNewPostion= new Vector3(m_xLength/2,m_yLength/2,-10);
        m_camera.transform.position = cameraNewPostion + m_CameraOffset;

        m_allCell = new List<GameObject>();
        DeleteCurrentGridMap();

        m_GridMapTransform.position = Vector3.zero;
        //GameObject[] gridMap = new GameObject[m_xLength,m_yLength]; 
        for (int x = 0; x< m_xLength; x++)
        {
            for (int y= 0; y< m_yLength; y++)
            {
                Vector2 position = new Vector2(x,y);
                GameObject obj = Instantiate(m_gridCellPrefab, position,Quaternion.identity,m_GridMapTransform);

                obj.name = x.ToString() + "," + y.ToString();
                m_allCell.Add(obj);
            }
        }
    }

    /// <summary>
    /// 这里可能会有一点小错误。我不管啦。
    /// </summary>
    public void DeleteCurrentGridMap()
    {
        List<Transform> allCell = new List<Transform>();
        allCell.AddRange( m_GridMapTransform.GetComponentsInChildren<Transform>());
        allCell.Remove(m_GridMapTransform);

        foreach (Transform obj in allCell)
        {
            DestroyImmediate(obj.gameObject);
            
        }



        allCell.Clear();


        //for(int i = 0; i< m_GridMapTransform.childCount; i++)
        //{
        //    DestroyImmediate(m_GridMapTransform.GetChild(i).gameObject);

        //}
        if (m_allCell!= null)
        {
            m_allCell.Clear();

        }


    }


}
