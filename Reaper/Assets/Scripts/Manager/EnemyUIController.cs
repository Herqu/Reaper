using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    public Transform m_EnemyIntentionUITranform;
    public Transform m_CharaImageUITranform;

    public GameObject m_EnemyAttackIntentionPrefab;
    public GameObject m_EnemyHurtPrefab;
    public GameObject m_CharaHurtPrefab;

    public Vector2 m_UIOffeset ;
    //[Range(0, 5f)]
    public float m_CharaHurtUIRange = 5f;


    public Camera m_MainCamera;



    private void Start()
    {
        m_MainCamera = Camera.main;
    }

    public  void NewIntention(Vector2 enemyPostion,float damage)
    {
        enemyPostion += m_UIOffeset;
        GameObject obj = Instantiate(m_EnemyAttackIntentionPrefab, m_MainCamera.WorldToScreenPoint(enemyPostion), Quaternion.identity, m_EnemyIntentionUITranform);
        Destroy(obj, 0.2f);

        //obj = Instantiate(m_CharaHurtPrefab, (Vector2)m_CharaImageUITranform.position + Random.insideUnitCircle*m_CharaHurtUIRange, Quaternion.identity, m_EnemyIntentionUITranform);
        //Destroy(obj, 0.2f);


        obj = Instantiate(m_EnemyHurtPrefab, (Vector2)m_CharaImageUITranform.position + Random.insideUnitCircle * m_CharaHurtUIRange+m_UIOffeset, Quaternion.identity, m_EnemyIntentionUITranform);
        obj.GetComponent<Text>().text = (-damage).ToString(); 
        Destroy(obj, 0.3f);
    }

    public void NewHurt(Vector2 enemyPostion, int damage)
    {
        enemyPostion += m_UIOffeset;

        GameObject obj = Instantiate(m_EnemyHurtPrefab, m_MainCamera.WorldToScreenPoint(enemyPostion), Quaternion.identity, m_EnemyIntentionUITranform);
        obj.GetComponent<Text>().text = (-damage).ToString(); 
        Destroy(obj, 0.2f);
    }

}

