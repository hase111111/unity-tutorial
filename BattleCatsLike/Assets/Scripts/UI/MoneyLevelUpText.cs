using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyLevelUpText : MonoBehaviour
{
    TextMeshProUGUI _text;
    MoneyCounter _moneyCounter;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    void Update()
    {
        _text.text = $"Level {_moneyCounter.Level}\n{_moneyCounter.GetLevelUpCost()}‰~";
    }
}
