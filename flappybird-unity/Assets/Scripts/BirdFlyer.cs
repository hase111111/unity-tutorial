using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyer : MonoBehaviour
{
    Rigidbody2D _rb;
    BirdDeadChecker _birdDeadChecker;
    readonly float _jumpForce = 2.0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _birdDeadChecker = GetComponent<BirdDeadChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_birdDeadChecker.IsDead)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
