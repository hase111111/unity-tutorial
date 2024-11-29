using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    readonly float _speed = 1.1f;
    BirdDeadChecker _birdDeadChecker;

    void Start()
    {
        // Player Tagged GameObject‚©‚çBirdDeadChecker‚ðŽæ“¾
        _birdDeadChecker = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdDeadChecker>();
    }

    void Update()
    {
        if (_birdDeadChecker.IsDead) return;

        transform.position += _speed * Time.deltaTime * Vector3.left;
    }
}
