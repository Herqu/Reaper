using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaUIManager : MonoBehaviour
{
    public Transform m_WeaponMagazineTransform;
    public GameObject m_CharaUIPrefab;

    public void AddNewUI(Sprite s)
    {
        Instantiate(m_CharaUIPrefab, m_WeaponMagazineTransform).GetComponent<Image>().sprite = s;
    }
}
