using UnityEngine;

public class PinchInputHandler : MonoBehaviour
{
    // 前フレームの指の間隔を記録する
    float previousDistance;

    float pinchDelta;

    void Update()
    {
        // タッチが2本以上検出されている場合のみ処理
        if (Input.touchCount == 2)
        {
            // 2本指のタッチ情報を取得
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // 2本指の現在位置の間隔を計算
            Vector2 currentPosition1 = touch1.position;
            Vector2 currentPosition2 = touch2.position;
            float currentDistance = Vector2.Distance(currentPosition1, currentPosition2);

            // タッチの開始時または初回の距離を記録
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                previousDistance = currentDistance;
                return;
            }

            // 指の間隔の変化量を計算
            pinchDelta = currentDistance - previousDistance;

            // 現在の距離を次のフレームに向けて記録
            previousDistance = currentDistance;
        }
    }

    public float GetPinchDelta()
    {
        // 変化量を返す
        return pinchDelta;
    }
}
