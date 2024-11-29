using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    TextMeshProUGUI _text;
    MoneyCounter _moneyCounter;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = $"{_moneyCounter.Money} / {_moneyCounter.GetMaxMoney()}‰~";
    }
}
