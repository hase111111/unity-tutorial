using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void OnClickStartButton()
    {
        // GameScene�ɑJ��
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickOptionButton()
    {
        // RankingScene�ɑJ��
        Debug.Log("OptionButton��������܂���");
    }
}
