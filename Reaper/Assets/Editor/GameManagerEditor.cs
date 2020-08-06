using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager m_gameManager= (GameManager)target;
        //GridCellSpawn m_CellSpawn= (GridCellSpawn)target;
            
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("CreateGridMap"))
        {
            m_gameManager.CreateGridMap();
            Debug.Log("新的地图成立啦");
        }
        if (GUILayout.Button("DeleteGridMap"))
        {
            m_gameManager.DeleteCurrentGridMap();
            Debug.Log("所有文件已经删除");
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("other");
        if (GUILayout.Button("布置物体"))
        {
            //m_gameManager.();
            Debug.Log("新的地图成立啦");
        }
    }
}
