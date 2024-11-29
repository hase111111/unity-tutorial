using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackProcessor : MonoBehaviour
{
    readonly List<ICharacterBehavior> _playerCharacterBehaviors = new();
    readonly List<ICharacterBehavior> _enemyCharacterBehaviors = new();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterPlayer(ICharacterBehavior _behavior)
    {
        _playerCharacterBehaviors.Add(_behavior);

        Debug.Log("Player‚ª“o˜^‚³‚ê‚Ü‚µ‚½");
    }

    public void RegisterEnemy(ICharacterBehavior _behavior)
    {
        _enemyCharacterBehaviors.Add(_behavior);

        Debug.Log("Enemy‚ª“o˜^‚³‚ê‚Ü‚µ‚½");
    }

    public float GetTopPlayerPositionX()
    {
        float topPositionX = 0;
        foreach (var behavior in _playerCharacterBehaviors)
        {
            if (topPositionX < behavior.PositionX)
            {
                topPositionX = behavior.PositionX;
            }
        }
        return topPositionX;
    }

    public float GetTopEnemyPositionX()
    {
        float topPositionX = float.MinValue;
        foreach (var behavior in _enemyCharacterBehaviors)
        {
            if (topPositionX < behavior.PositionX)
            {
                topPositionX = behavior.PositionX;
            }
        }
        return topPositionX;
    }
}
