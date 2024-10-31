using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    readonly float _jumpInterval = 0.1f;
    float _jumpIntervalCounter = 0.0f;

    [SerializeField] float _jumpForce = 300.0f;
    [SerializeField] GameObject _boomEffect;

    public float JumpY { get; set; } = -3.0f;

    void Start()
    {
        if (!TryGetComponent<Rigidbody2D>(out _rb))
        {
            Debug.LogError("Rigidbody2D is not attached.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // マウスクリックでジャンプ
        if (Input.GetMouseButtonDown(0) || transform.position.y < JumpY)
        {
            if (_jumpIntervalCounter > 0.0f) return;

            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _jumpForce);

            _jumpIntervalCounter = _jumpInterval;
        }

        // ジャンプ間隔を減少
        if (_jumpIntervalCounter > 0.0f)
        {
            _jumpIntervalCounter -= Time.deltaTime;
        }
    }

    // 衝突判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトのタグが Obstacle だったらゲームオーバー
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 死亡時のエフェクトを再生
            var obj = Instantiate(_boomEffect, transform.position, Quaternion.identity);
            Destroy(obj, 3.0f);

            gameObject.SetActive(false);
        }
    }
}
