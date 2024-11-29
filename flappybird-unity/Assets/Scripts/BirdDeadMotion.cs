using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDeadMotion : MonoBehaviour
{
    BirdDeadChecker _birdDeadChecker;
    Animator _animator;
    Rigidbody2D _rigidBody2d;
    bool _once = false;

    // Start is called before the first frame update
    void Start()
    {
        _birdDeadChecker = GetComponent<BirdDeadChecker>();
        _animator = GetComponent<Animator>();
        _rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_birdDeadChecker.IsDead)
        {
            if (!_once)
            {
                Debug.Log("Bird is dead");

                // animationÇí‚é~
                _animator.enabled = false;
                _once = true;

                // ìÆçÏÇí‚é~
                _rigidBody2d.velocity = Vector2.zero;
                _rigidBody2d.gravityScale = 0;
            }
        }
    }
}
