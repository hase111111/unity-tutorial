using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void OnClickRetryButton()
    {
        Debug.Log("OnClickRetryButton");
        FadeUpdater fadeUpdater = FindObjectOfType<FadeUpdater>();
        fadeUpdater.OnFadeEnd = () =>
         {
             Debug.Log("FadeEnd");
             // シーンを再読み込み
             UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
         };
        fadeUpdater.FadeOut(1);
    }

    public void OnClickTitleButton()
    {
        Debug.Log("OnClickTitleButton");
        FadeUpdater fadeUpdater = FindObjectOfType<FadeUpdater>();
        fadeUpdater.OnFadeEnd = () =>
         {
             Debug.Log("FadeEnd");
             // シーンを再読み込み
             UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
         };
        fadeUpdater.FadeOut(1);
    }
}
