
public class NormalCatBehavior : ICharacterBehavior
{
    public float PositionX { get; set; }
    public float Speed { get; } = 0.0075f;
    public float Distance { get; } = 0.5f;
    readonly int _maxHp = 100;
    int _hp;

    public NormalCatBehavior()
    {
        _hp = _maxHp;
    }

    public void Damage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            //Ž€–Sˆ—
        }
    }
}
