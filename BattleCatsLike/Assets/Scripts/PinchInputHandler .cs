using UnityEngine;

public class PinchInputHandler : MonoBehaviour
{
    // �O�t���[���̎w�̊Ԋu���L�^����
    float previousDistance;

    float pinchDelta;

    void Update()
    {
        // �^�b�`��2�{�ȏ㌟�o����Ă���ꍇ�̂ݏ���
        if (Input.touchCount == 2)
        {
            // 2�{�w�̃^�b�`�����擾
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // 2�{�w�̌��݈ʒu�̊Ԋu���v�Z
            Vector2 currentPosition1 = touch1.position;
            Vector2 currentPosition2 = touch2.position;
            float currentDistance = Vector2.Distance(currentPosition1, currentPosition2);

            // �^�b�`�̊J�n���܂��͏���̋������L�^
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                previousDistance = currentDistance;
                return;
            }

            // �w�̊Ԋu�̕ω��ʂ��v�Z
            pinchDelta = currentDistance - previousDistance;

            // ���݂̋��������̃t���[���Ɍ����ċL�^
            previousDistance = currentDistance;
        }
    }

    public float GetPinchDelta()
    {
        // �ω��ʂ�Ԃ�
        return pinchDelta;
    }
}
