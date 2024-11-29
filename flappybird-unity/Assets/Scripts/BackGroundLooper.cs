using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLooper : MonoBehaviour
{
    [SerializeField] Sprite _sprite;
    BirdDeadChecker _birdDeadChecker;
    readonly float _speed = 1.0f;
    float _width;
    public bool NowMoving { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        _width = _sprite.bounds.size.x;
        _birdDeadChecker = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdDeadChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!NowMoving) return;
        if (_birdDeadChecker.IsDead) return;

        transform.position += _speed * Time.deltaTime * Vector3.left;

        if (transform.position.x <= -_width)
        {
            transform.position += Vector3.right * _width;
        }
    }
}
