using UnityEngine;

public class Player : MonoBehaviour
{
    float _speed = 5.0f;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        // animator を取得
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 入力を受け取って移動する
        float move = Move();

        // 移動する場合，アニメータのisWalkingを true にする
        if (move > 0.4)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    float Move()
    {
        float x, z;

        // 上下左右の入力を受け取る
        if (Input.GetKey(KeyCode.W))
        {
            z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            z = -1;
        }
        else
        {
            z = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }
        else
        {
            x = 0;
        }

        // 入力方向に移動する
        Vector3 direction = new Vector3(x, 0, z);
        transform.position += direction.normalized * _speed * Time.deltaTime;

        // 移動方向を向く
        if (direction.magnitude > 0.1)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        return direction.magnitude;
    }
}
