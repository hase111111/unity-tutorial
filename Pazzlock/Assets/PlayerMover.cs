using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 5.0f;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;

    float _velocityX = 0f;
    float _velocityY = 0f;

    // Update is called once per frame
    void Update()
    {
        _velocityX = Input.GetAxis("Horizontal") * _speed;
        _velocityY = Input.GetAxis("Vertical") * _speed;

        _rb.velocity = new Vector2(_velocityX, _velocityY);

        if (_velocityX != 0 || _velocityY != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else 
        {
            _animator.SetBool("isWalking", false);
        }

        if (_velocityX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_velocityX < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
