using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOBJController : MonoBehaviour
{
    public List<GameObject> m_AttackOBJType = new List<GameObject>();
    public List<GameObject> m_CurrentAttackOBJ = new List<GameObject>();

    //public float m_WaitInterval = 0.1f;

    private void Update()
    {

        //if (m_CurrentAttackOBJ.Count == 0)
        //{
        //    GetComponent<CellOBJManager>().RemoveRegistCell();
        //}

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    GetComponent<CellOBJManager>().RemoveRegistCell();

        //}
    }

    private void FixedUpdate()
    {
        if (m_CurrentAttackOBJ.Count == 0)
        {
            GetComponent<CellOBJManager>().RemoveRegistCell();
        }
    }

    public void AddAttackOBJ(GameObject obj)
    {
        m_CurrentAttackOBJ.Add(obj);
    }

    public void RemoveAttackOBJ(GameObject obj)
    {
        m_CurrentAttackOBJ.Remove(obj);
    }
}
