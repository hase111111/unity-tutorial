using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastleBehaviour : ICharacterBehavior
{
    public PlayerCastleBehaviour(float pos)
    {
        PositionX = pos;
    }

    public float PositionX { get; set; }

    //�_���[�W��^����
    public void Damage(int damage) { }
}

public class PlayerCastle : MonoBehaviour
{
    PlayerCastleBehaviour playerCastleBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        var stageParameter = GameObject.FindObjectOfType<StageParameter>();
        playerCastleBehaviour = new PlayerCastleBehaviour(stageParameter.PlayerCastlePositionX);

        var characterAttackProcessor = FindObjectOfType<CharacterAttackProcessor>();
        characterAttackProcessor.RegisterPlayer(playerCastleBehaviour);
    }
}
