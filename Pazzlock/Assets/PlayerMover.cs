using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 5.0f;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] GameObject _gameClearEffct;

    float _velocityX = 0f;
    float _velocityY = 0f;

    bool _isGameClear = false;

    private void Start()
    {
        _gameClearEffct.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameClear) return;

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

    public void GameClear() 
    {
        _isGameClear = true;

        _animator.SetBool("cheer", true);

        _gameClearEffct.SetActive(true);
    }
}
