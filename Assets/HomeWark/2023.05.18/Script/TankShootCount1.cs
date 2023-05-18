using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankShootCount1 : MonoBehaviour
{
    private TMP_Text m_Text;

    private void Awake()
    {
        m_Text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        GameManager.Data.OnShootChanged += ChangeText;
    }

    private void OnDisable()
    {
        GameManager.Data.OnShootChanged -= ChangeText;
    }

    private void ChangeText(int count)
    {
        m_Text.text = count.ToString();
    }
}
