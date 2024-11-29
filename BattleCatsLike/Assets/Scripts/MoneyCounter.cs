using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public int Money { get; set; } = 0;
    int _level = 1;
    readonly int _maxLevel = 8;
    readonly int[] _levelUpCost = { 560, 1120, 1680, 2240, 2800, 3360, 3920 };
    readonly int[] _maxMoney = { 6000, 7500, 9000, 10500, 12000, 13500, 15000, 16500 };
    readonly int[] _moneyPerSec = { 185, 193, 203, 212, 222, 231, 241, 250 };

    void FixedUpdate()
    {
        float _deltaMoney = _moneyPerSec[_level - 1] * Time.deltaTime;
        Money += (int)_deltaMoney;

        if (Money > _maxMoney[_level - 1])
        {
            Money = _maxMoney[_level - 1];
        }
    }

    public void LevelUp()
    {
        if (_level < _maxLevel && Money >= _levelUpCost[_level - 1])
        {
            Money -= _levelUpCost[_level - 1];
            _level++;
        }
    }

    public bool CanLevelUp()
    {
        return _level < _maxLevel && Money >= _levelUpCost[_level - 1];
    }

    public int GetMaxMoney()
    {
        return _maxMoney[_level - 1];
    }
}
