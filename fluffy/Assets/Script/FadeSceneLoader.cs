using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fadePanel;             // フェード用のUIパネル（Image）
    public float fadeDuration = 1.0f;   // フェードの完了にかかる時間
    [SerializeField] Color _startColor;
    [SerializeField] Color _endColor;

    Action _onFadeEnd = () => { };      // フェード完了時に実行する処理

    public void SetCallBack(Action onFadeEnd)
    {
        _onFadeEnd = onFadeEnd;
    }

    public void CallCoroutine()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        fadePanel.enabled = true;                 // パネルを有効化
        float elapsedTime = 0.0f;                 // 経過時間を初期化

        // フェードアウトアニメーションを実行
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                        // 経過時間を増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // フェードの進行度を計算
            fadePanel.color = Color.Lerp(_startColor, _endColor, t); // パネルの色を変更してフェードアウト
            yield return null;                                     // 1フレーム待機
        }

        fadePanel.color = _endColor;  // フェードが完了したら最終色に設定

        // フェード完了時の処理を実行
        _onFadeEnd();
    }
}
