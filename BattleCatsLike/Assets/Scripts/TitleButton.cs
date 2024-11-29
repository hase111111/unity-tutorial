using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void OnClickStartButton()
    {
        // GameSceneに遷移
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickOptionButton()
    {
        // RankingSceneに遷移
        Debug.Log("OptionButtonが押されました");
    }
}
