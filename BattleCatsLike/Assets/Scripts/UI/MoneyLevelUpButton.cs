using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyLevelUpButton : MonoBehaviour
{
    MoneyCounter _moneyCounter;
    [SerializeField] Button _button;

    void Start()
    {
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // レベルが足りていない場合 or 最大レベルの場合，ボタンを非活性化
        _button.interactable = _moneyCounter.CanLevelUp();
    }

    public void OnClick()
    {
        _moneyCounter.LevelUp();
    }
}
