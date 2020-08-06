
using UnityEngine;

public class GridOBJ : MonoBehaviour
{
    public CellOBJManager m_CellOBJManager;
    //public GridCell  m_CurrentGridCell;


    public Witcher m_Witcher;







    public void Initialize(CellOBJManager com)
    {
        m_Witcher = GameObject.FindGameObjectWithTag("Player").GetComponent<Witcher>();
        m_CellOBJManager = com;
    }








}
