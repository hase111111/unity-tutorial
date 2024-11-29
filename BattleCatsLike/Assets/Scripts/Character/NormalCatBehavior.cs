
public class NormalCatBehavior : ICharacterBehavior
{
    public int PositionX { get; set; }
    public float Speed { get; } = 0.0075f;
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
