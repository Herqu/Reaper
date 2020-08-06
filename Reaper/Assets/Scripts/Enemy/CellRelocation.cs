using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRelocation : MonoBehaviour
{

    public Vector2 m_CurrentSPeed;
    public float m_RelocationTime = 0.1f;
    

    private void Update()
    {
        if(transform.parent.position != transform.position)
        {
            //transform.Translate();
            transform.position = Vector2.SmoothDamp(transform.position, transform.parent.position, ref m_CurrentSPeed, m_RelocationTime);
        }   
    }
}
