using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class LanternUIscript : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] LanternEvents m_lantnum;
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        int numleft = m_lantnum.LanternsInLevel - m_lantnum.LanternsLit;
        GetComponent<TextMeshProUGUI>().text = "There is " + numleft + "Lanterns left";
    }
}
