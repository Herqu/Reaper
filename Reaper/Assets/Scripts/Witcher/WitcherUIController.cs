using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitcherUIController : MonoBehaviour
{


    public Slider m_BloodSlider;
    public Slider m_EnergySlider;


    private void Update()
    {
        m_BloodSlider.value = GetComponent<Witcher>().m_LeftBlood / GetComponent<Witcher>().m_fullBlood;
        m_EnergySlider.value = GetComponent<WitcherWeapon>().m_CurrentEnergy / GetComponent<WitcherWeapon>().m_FullEnergy;
    }
}
