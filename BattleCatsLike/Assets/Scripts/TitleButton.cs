using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void OnClickStartButton()
    {
        // GameScene‚É‘JˆÚ
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickOptionButton()
    {
        // RankingScene‚É‘JˆÚ
        Debug.Log("OptionButton‚ª‰Ÿ‚³‚ê‚Ü‚µ‚½");
    }
}
