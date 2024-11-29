using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public int Money { get; set; } = 0;
    public int Level { get; set; } = 1;
    readonly public int MaxLevel = 8;
    readonly int[] _levelUpCost = { 560, 1120, 1680, 2240, 2800, 3360, 3920 };
    readonly int[] _maxMoney = { 6000, 7500, 9000, 10500, 12000, 13500, 15000, 16500 };
    readonly int[] _moneyPerSec = { 185, 193, 203, 212, 222, 231, 241, 250 };

    void FixedUpdate()
    {
        float _deltaMoney = _moneyPerSec[Level - 1] * Time.deltaTime;
        Money += (int)_deltaMoney;

        if (Money > _maxMoney[Level - 1])
        {
            Money = _maxMoney[Level - 1];
        }
    }

    public void LevelUp()
    {
        if (Level < MaxLevel && Money >= _levelUpCost[Level - 1])
        {
            Money -= _levelUpCost[Level - 1];
            Level++;
        }
    }

    public bool CanLevelUp()
    {
        return Level < MaxLevel && Money >= _levelUpCost[Level - 1];
    }

    public int GetMaxMoney()
    {
        return _maxMoney[Level - 1];
    }
}
