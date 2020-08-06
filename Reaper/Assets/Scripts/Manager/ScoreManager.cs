using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text m_ScoreText;
    public int m_ScoreNum;

    public void AddScroe()
    {
        m_ScoreNum += 1;
    }

    private void Awake()
    {
        m_ScoreNum = 0;
    }

    private void Update()
    {
        m_ScoreText.text = m_ScoreNum.ToString();
    }
}
