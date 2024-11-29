using UnityEngine;

public class SwipeInputHandler : MonoBehaviour
{
    Vector2 endTouchPosition;   // タッチ終了位置
    Vector2 swipeDelta;         // スワイプ量

    bool isSwiping = false;     // スワイプ中の状態

    void Update()
    {
        // タッチが1本検出されている場合
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // タッチ開始時
            if (touch.phase == TouchPhase.Began)
            {
                endTouchPosition = touch.position;
                isSwiping = true;
            }

            // タッチ中
            if (isSwiping && touch.phase == TouchPhase.Moved)
            {
                swipeDelta = touch.position - endTouchPosition;
                endTouchPosition = touch.position;
            }
            else
            {
                swipeDelta = Vector2.zero; // スワイプ量をリセット
            }

            // タッチ終了時
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isSwiping = false;
                swipeDelta = Vector2.zero; // スワイプ量をリセット
            }
        }
    }

    public Vector2 GetSwipeDelta()
    {
        // スワイプ量を返す
        return swipeDelta;
    }

    public bool IsSwiping()
    {
        // スワイプ中かどうかを返す
        return isSwiping;
    }
}
