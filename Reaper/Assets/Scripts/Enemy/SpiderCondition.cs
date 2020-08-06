using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCondition : MonoBehaviour
{

    [Header("血量和死亡操作")]
    public int m_Curretnblood = 10;
    public int m_Fullblood = 10;


    private void Start()
    {
        m_Curretnblood = m_Fullblood;
    }

    public void Hurt(int damage)
    {

        GetComponent<GridOBJ>().m_CellOBJManager.GetComponent<EnemyUIController>().NewHurt(transform.position,damage) ;

        m_Curretnblood -= damage;
        if (m_Curretnblood <= 0)
        {
            Dead();

        }
        //Debug.Log("我被烧伤啦");
    }

    public void Dead()
    {
        GetComponent<GridOBJ>().m_CellOBJManager.GetComponent<ScoreManager>().AddScroe();
        Destroy(gameObject);

    }

    /// <summary>
    /// 眩晕物体
    /// </summary>

}
