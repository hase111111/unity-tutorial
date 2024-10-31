using UnityEngine;

public class Player : MonoBehaviour
{
    float _speed = 5.0f;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        // animator ���擾
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��󂯎���Ĉړ�����
        float move = Move();

        // �ړ�����ꍇ�C�A�j���[�^��isWalking�� true �ɂ���
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

        // �㉺���E�̓��͂��󂯎��
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

        // ���͕����Ɉړ�����
        Vector3 direction = new Vector3(x, 0, z);
        transform.position += direction.normalized * _speed * Time.deltaTime;

        // �ړ�����������
        if (direction.magnitude > 0.1)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        return direction.magnitude;
    }
}
