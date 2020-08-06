using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class GridEditor : EditorWindow
{
    public int xRange;
    public int yRange;
    GameObject gridCell;


    [MenuItem("MyEditor/Create Grid")]
    public static void CreateGrid()
    {

        EditorWindow.GetWindow<GridEditor>("GridWindow");


        //Camera.main.transform.position = new Vector3(0, 0, 0); ;

    }



    private void OnGUI()
    {
        GUILayout.Label("GridWindowEditor", EditorStyles.boldLabel);

        xRange = EditorGUILayout.IntField("X Ray Lenth", xRange);
        yRange = EditorGUILayout.IntField("Y Ray Lenth", yRange);

        //gridCell = EditorGUILayout.field(gridCell);

        if (GUILayout.Button("CreatNewGrid"))
        {
            //Instantiate()
        }
    }


}

//[CustomEditor(typeof(GridEditor))]
//public class MyEditor : Editor
//{

//}
