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
    void FixedUpdate()
    {
        transform.position -= new Vector3(_behavior.Speed, 0, 0);

        // ç≈ëOóÒÇ…Ç¢ÇÈìGÇí¥Ç¶Ç»Ç¢
        if (transform.position.x < _processor.GetTopEnemyPositionX() + _behavior.Distance)
        {
            Vector3 pos = transform.position;
            pos.x = _processor.GetTopEnemyPositionX() + _behavior.Distance;
            transform.position = pos;
        }

        _behavior.PositionX = transform.position.x;
    }
}
