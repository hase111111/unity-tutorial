using UnityEngine;

public class SwipeInputHandler : MonoBehaviour
{
    Vector2 endTouchPosition;   // �^�b�`�I���ʒu
    Vector2 swipeDelta;         // �X���C�v��

    bool isSwiping = false;     // �X���C�v���̏��

    void Update()
    {
        // �^�b�`��1�{���o����Ă���ꍇ
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // �^�b�`�J�n��
            if (touch.phase == TouchPhase.Began)
            {
                endTouchPosition = touch.position;
                isSwiping = true;
            }

            // �^�b�`��
            if (isSwiping && touch.phase == TouchPhase.Moved)
            {
                swipeDelta = touch.position - endTouchPosition;
                endTouchPosition = touch.position;
            }
            else
            {
                swipeDelta = Vector2.zero; // �X���C�v�ʂ����Z�b�g
            }

            // �^�b�`�I����
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isSwiping = false;
                swipeDelta = Vector2.zero; // �X���C�v�ʂ����Z�b�g
            }
        }
    }

    public Vector2 GetSwipeDelta()
    {
        // �X���C�v�ʂ�Ԃ�
        return swipeDelta;
    }

    public bool IsSwiping()
    {
        // �X���C�v�����ǂ�����Ԃ�
        return isSwiping;
    }
}
