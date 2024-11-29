using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField] GameObject titleOptionPanel;

    public void OnClickStartButton()
    {
        // GameScene‚É‘JˆÚ
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickCreditButton()
    {
        titleOptionPanel.SetActive(true);
    }
}
