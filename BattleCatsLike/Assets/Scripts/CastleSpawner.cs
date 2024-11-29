using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleSpawner : MonoBehaviour
{
    StageParameter _stageParameter;
    [SerializeField] GameObject _playerCastle;
    [SerializeField] GameObject _enemyCastle;

    // Start is called before the first frame update
    void Start()
    {
        _stageParameter = GameObject.FindAnyObjectByType<StageParameter>();

        // ƒvƒŒƒCƒ„[‚Ìé‚ğ¶¬
        GameObject playerCastle = Instantiate(_playerCastle, new Vector3(0, 0, 0), Quaternion.identity);
        Vector3 player_trans = new(_stageParameter.PlayerCastlePositionX, _stageParameter.CastlePositionY, 0);
        playerCastle.transform.position = player_trans;


        // “G‚Ìé‚ğ¶¬
        GameObject enemyCastle = Instantiate(_enemyCastle, new Vector3(0, 0, 0), Quaternion.identity);
        Vector3 enemy_trans = new(_stageParameter.EnemyCastlePositionX, _stageParameter.CastlePositionY, 0);
        enemyCastle.transform.position = enemy_trans;
    }
}
