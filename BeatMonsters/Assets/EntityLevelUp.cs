
using System;

public class EntityLevelUp
{
    readonly int _minLevel = 1;
    readonly int _maxLevel = 99;
    readonly int _minMonsterHealth = 5;
    readonly int _maxMonsterHealth = 100000;
    readonly float _healthMultiplier = 2.5f;
    readonly float _coinMultiplier = 5.0f;

    public int GetMonsterHealth(int kill_count)
    {
        float temp = MathF.Pow((float)kill_count / _maxLevel, _healthMultiplier);

        return (int)((_maxMonsterHealth - _minMonsterHealth) * temp) + _minMonsterHealth;
    }

    public int GetCoin(int kill_count)
    {
        return (int)(GetMonsterHealth(kill_count - 1) * _coinMultiplier);
    }

    public int GetPower(int level)
    {
        // レベルに応じたパワーを返す
        // y= 999 / ln(99) * ln(x) + 1
        return (int)(999 / MathF.Log(_maxLevel) * MathF.Log(level) + 1);
    }
}
