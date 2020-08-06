using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBloodUIController : MonoBehaviour
{

    public SpriteRenderer m_SpriteBloocRentder;
    [Range(0,1f)]
    public float m_CurrentBloodValue = 1.5f;

    private void Update()
    {
        m_CurrentBloodValue = (float)GetComponent<SpiderCondition>().m_Curretnblood / (float)GetComponent<SpiderCondition>().m_Fullblood;
        m_SpriteBloocRentder.size = new Vector2(1,m_CurrentBloodValue);
    }
}
