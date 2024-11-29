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
        // ���x��������Ă��Ȃ��ꍇ or �ő僌�x���̏ꍇ�C�{�^����񊈐���
        _button.interactable = _moneyCounter.CanLevelUp();
    }

    public void OnClick()
    {
        _moneyCounter.LevelUp();
    }
}
