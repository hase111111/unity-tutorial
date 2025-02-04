using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCat : MonoBehaviour
{
    readonly NormalCatBehavior _behavior = new();
    CharacterAttackProcessor _processor;

    void Start()
    {
        _processor = FindObjectOfType<CharacterAttackProcessor>();
        _processor.RegisterPlayer(_behavior);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(_behavior.Speed, 0, 0);

        // 最前列にいる敵を超えない
        if (transform.position.x < _processor.GetTopEnemyPositionX() + _behavior.Distance)
        {
            Vector3 pos = transform.position;
            pos.x = _processor.GetTopEnemyPositionX() + _behavior.Distance;
            transform.position = pos;
        }

        _behavior.PositionX = transform.position.x;
    }
}
