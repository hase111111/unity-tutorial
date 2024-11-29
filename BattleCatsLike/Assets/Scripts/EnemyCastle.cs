using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCastleBehaviour : ICharacterBehavior
{
    public EnemyCastleBehaviour(float pos)
    {
        PositionX = pos;
    }

    public float PositionX { get; set; }

    //É_ÉÅÅ[ÉWÇó^Ç¶ÇÈ
    public void Damage(int damage) { }
}

public class EnemyCastle : MonoBehaviour
{
    EnemyCastleBehaviour playerCastleBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        var stageParameter = GameObject.FindObjectOfType<StageParameter>();
        playerCastleBehaviour = new EnemyCastleBehaviour(stageParameter.EnemyCastlePositionX);

        var characterAttackProcessor = FindObjectOfType<CharacterAttackProcessor>();
        characterAttackProcessor.RegisterEnemy(playerCastleBehaviour);
    }
}
