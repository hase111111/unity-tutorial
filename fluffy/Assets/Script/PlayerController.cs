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
        // �}�E�X�N���b�N�ŃW�����v
        if (Input.GetMouseButtonDown(0) || transform.position.y < JumpY)
        {
            if (_jumpIntervalCounter > 0.0f) return;

            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _jumpForce);

            _jumpIntervalCounter = _jumpInterval;
        }

        // �W�����v�Ԋu������
        if (_jumpIntervalCounter > 0.0f)
        {
            _jumpIntervalCounter -= Time.deltaTime;
        }
    }

    // �Փ˔���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O�� Obstacle ��������Q�[���I�[�o�[
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // ���S���̃G�t�F�N�g���Đ�
            var obj = Instantiate(_boomEffect, transform.position, Quaternion.identity);
            Destroy(obj, 3.0f);

            gameObject.SetActive(false);
        }
    }
}
